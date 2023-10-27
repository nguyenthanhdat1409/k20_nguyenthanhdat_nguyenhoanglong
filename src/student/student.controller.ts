import { Body, Controller, Get, Param, Post, Query } from '@nestjs/common';
import { StudentService } from './student.service';
import { CreateStudentDto } from './dto/create-student.dto';

@Controller('student')
export class StudentController {
  constructor(private readonly studentService: StudentService) { }
  @Post()
  create(@Body() createStudentDto: CreateStudentDto) {
    return this.studentService.create(createStudentDto);
  }

  @Get()
  findAll(@Query('current') currentPage: string,
    @Query('pageSize') limit: string,
    @Query() qs: string) {
    return this.studentService.findAll(+currentPage, +limit, qs);
  }
  @Get("/sector")
  findAllSector(@Body('sector') sector: string, @Body('point') point: string) {
    return this.studentService.findAllSector(sector, point);
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    return this.studentService.findOne(id);
  }


}
