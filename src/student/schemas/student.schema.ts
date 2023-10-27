import { Prop, Schema, SchemaFactory } from '@nestjs/mongoose';
import mongoose, { HydratedDocument } from 'mongoose';
import { Studentpoint } from 'src/studentpoint/schemas/studentpoint.schema';

export type StudentDocument = HydratedDocument<Student>;

@Schema()
export class Student {
    @Prop()
    mssv: string;

    @Prop()
    name: string;

    @Prop()
    gender: string;

    @Prop()
    birthday: string;

    @Prop()
    birthplace: string;

    @Prop()
    class: string;

    @Prop()
    sector: string;

}

export const StudentSchema = SchemaFactory.createForClass(Student);