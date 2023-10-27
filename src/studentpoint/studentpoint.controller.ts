import { Controller, Get, Post, Body, Query, Param } from '@nestjs/common';
import { StudentpointService } from './studentpoint.service';
import { CreateStudentpointDto } from './dto/create-studentpoint.dto';

@Controller('studentpoint')
export class StudentpointController {
  constructor(private readonly studentpointService: StudentpointService) { }

  @Post()
  create(@Body() createStudentpointDto: CreateStudentpointDto) {
    return this.studentpointService.create(createStudentpointDto);
  }

  @Get()
  findAll(@Query('current') currentPage: string,
    @Query('pageSize') limit: string,
    @Query() qs: string) {
    return this.studentpointService.findAll(+currentPage, +limit, qs);
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    return this.studentpointService.findOne(id);
  }


}
