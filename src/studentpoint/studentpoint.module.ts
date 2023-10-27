import { Module } from '@nestjs/common';
import { StudentpointService } from './studentpoint.service';
import { StudentpointController } from './studentpoint.controller';
import { MongooseModule } from '@nestjs/mongoose';
import { Studentpoint, StudentpointSchema } from './schemas/studentpoint.schema';

@Module({
  imports: [MongooseModule.forFeature([{ name: Studentpoint.name, schema: StudentpointSchema }])],
  controllers: [StudentpointController],
  providers: [StudentpointService],
})
export class StudentpointModule { }
