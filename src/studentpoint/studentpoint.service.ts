import { BadRequestException, Injectable } from '@nestjs/common';
import { CreateStudentpointDto } from './dto/create-studentpoint.dto';
import mongoose, { Model } from 'mongoose';
import { InjectModel } from '@nestjs/mongoose';
import { Studentpoint, StudentpointDocument } from './schemas/studentpoint.schema';
import aqp from 'api-query-params';
import { isEmpty } from 'class-validator';

@Injectable()
export class StudentpointService {
  constructor(
    @InjectModel(Studentpoint.name)
    private studentpointModel: Model<StudentpointDocument>
  ) { }
  async create(createStudentpointDto: CreateStudentpointDto) {
    return await this.studentpointModel.create({
      ...createStudentpointDto
    });
  }

  async findAll(currentPage: number, limit: number, qs: string) {
    const { filter, population } = aqp(qs);
    let { sort } = aqp(qs);

    delete filter.current;
    delete filter.pageSize;
    const offset = (+currentPage - 1) * (+limit);
    const defaultLimit = +limit ? +limit : 10;

    const totalItems = (await this.studentpointModel.find(filter)).length;
    const totalPages = Math.ceil(totalItems / defaultLimit);
    if (isEmpty(sort)) {
      // eslint-disable-next-line @typescript-eslint/ban-ts-comment
      //@ts-ignore: Unreachable code error
      sort = "-avapoint"
    }
    const result = await this.studentpointModel.find(filter)
      .skip(offset)
      .limit(defaultLimit)
      // eslint-disable-next-line @typescript-eslint/ban-ts-comment
      // @ts-ignore: Unreachable code error
      .sort(sort)
      .populate(population)
      .exec();
    console.log(sort)
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

  async findOne(id: string) {
    const sv = await this.studentpointModel.findOne({ mssv: id });
    if (sv) {
      return sv
    } else {
      throw new BadRequestException(`Không tìm thấy sinh viên`);
    }
  }



}
