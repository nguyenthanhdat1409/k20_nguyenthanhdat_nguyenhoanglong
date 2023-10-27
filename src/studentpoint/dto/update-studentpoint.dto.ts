import { PartialType } from '@nestjs/mapped-types';
import { CreateStudentpointDto } from './create-studentpoint.dto';

export class UpdateStudentpointDto extends PartialType(CreateStudentpointDto) {}
