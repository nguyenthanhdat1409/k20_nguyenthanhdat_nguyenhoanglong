import { Prop, Schema, SchemaFactory } from '@nestjs/mongoose';
import { HydratedDocument } from 'mongoose';

export type StudentpointDocument = HydratedDocument<Studentpoint>;

@Schema()
export class Studentpoint {
    @Prop()
    mssv: string;

    @Prop()
    avapoint: string;

    @Prop()
    tctl: string;

    @Prop()
    tmdh: string;

}

export const StudentpointSchema = SchemaFactory.createForClass(Studentpoint);