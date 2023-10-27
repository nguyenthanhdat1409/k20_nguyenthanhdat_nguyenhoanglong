import { BadRequestException, Injectable } from '@nestjs/common';
import { InjectModel } from '@nestjs/mongoose';
import aqp from 'api-query-params';
import { Model } from 'mongoose';
import { Student, StudentDocument } from './schemas/student.schema';
import { isEmpty } from 'class-validator';
import { CreateStudentDto } from './dto/create-student.dto';

@Injectable()
export class StudentService {
  constructor(
    @InjectModel(Student.name)
    private studentModel: Model<StudentDocument>
  ) { }
  async create(createStudentDto: CreateStudentDto) {
    return await this.studentModel.create({
      ...createStudentDto
    });
  }
  async findAll(currentPage: number, limit: number, qs: string) {
    const { filter, population } = aqp(qs);
    let { sort } = aqp(qs);
    delete filter.current;
    delete filter.pageSize;
    const offset = (+currentPage - 1) * (+limit);
    const defaultLimit = +limit ? +limit : 10;

    const totalItems = (await this.studentModel.find(filter)).length;
    const totalPages = Math.ceil(totalItems / defaultLimit);
    if (isEmpty(sort)) {
      // eslint-disable-next-line @typescript-eslint/ban-ts-comment
      //@ts-ignore: Unreachable code error
      sort = "-updatedAt"
    }
    const result = await this.studentModel.find(filter).populate({ path: "mssv", select: { avapoint: 1 } })
      .skip(offset)
      .limit(defaultLimit)
      // eslint-disable-next-line @typescript-eslint/ban-ts-comment
      // @ts-ignore: Unreachable code error
      .sort(sort)
      .populate(population)
      .exec();
    return {
      meta: {
        current: currentPage,
        pageSize: limit,
        pages: totalPages,
        total: totalItems
      },
      result
    }
  }
  async findAllSector(sector: string, point: string) {
    const result = await this.studentModel
      .aggregate([
        {
          $match: {
            $expr: {
              $eq: ['$sector', sector]
            }
          },
        },
        {
          $lookup: {
            from: 'studentpoints', // Tên của bảng "posts"
            let: { mssv: '$mssv' }, // Biến để truy cập vào trường "userCode" trong bảng "users"
            pipeline: [
              {
                $match: {
                  $expr: {
                    $eq: ['$mssv', '$$mssv'], // So sánh trường "userCode" của bảng "posts" với "userCode" trong bảng "users"
                  },
                },
              },
              {
                $project: {
                  _id: 0,
                  avapoint: 1,
                },
              },

            ],
            as: 'populatedStudent', // Tên của thuộc tính mới sẽ được populate
          },
        },
        {
          $match: {
            'populatedStudent.avapoint': {
              $lt: point
            }
          },
        },
        {
          $sort: {
            'populatedStudent.avapoint': -1, // Sắp xếp danh sách theo trường "content" trong "populatedPosts"
          },
        },
        {
          $limit: 5, // Giới hạn số lượng người dùng trả về
        },
      ])
    const result1 = await this.studentModel
      .aggregate([
        {
          $match: {
            $expr: {
              $eq: ['$sector', sector]
            }
          },
        },
        {
          $lookup: {
            from: 'studentpoints', // Tên của bảng "posts"
            let: { mssv: '$mssv' }, // Biến để truy cập vào trường "userCode" trong bảng "users"
            pipeline: [
              {
                $match: {
                  $expr: {
                    $eq: ['$mssv', '$$mssv'], // So sánh trường "userCode" của bảng "posts" với "userCode" trong bảng "users"
                  },
                },
              },
              {
                $project: {
                  _id: 0,
                  avapoint: 1,
                },
              },

            ],
            as: 'populatedStudent', // Tên của thuộc tính mới sẽ được populate
          },
        },
        {
          $match: {
            'populatedStudent.avapoint': {
              $gt: point
            }
          },
        },
        {
          $sort: {
            'populatedStudent.avapoint': -1, // Sắp xếp danh sách theo trường "content" trong "populatedPosts"
          },
        },
        {
          $limit: 5, // Giới hạn số lượng người dùng trả về
        },
      ])
    result1.push(...result)
    return result1
  }

  async findOne(id: string) {
    const sv = await this.studentModel.findOne({ mssv: id });
    if (sv) {
      return sv
    } else {
      throw new BadRequestException(`Không tìm thấy sinh viên`);
    }
  }


}
