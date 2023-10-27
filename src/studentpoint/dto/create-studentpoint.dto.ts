import { IsNotEmpty } from "class-validator"

export class CreateStudentpointDto {
    @IsNotEmpty({ message: "MSSV không được để trống" })
    mssv: string

    @IsNotEmpty({ message: "Điểm trung bình không được để trống" })
    avapoint: string

    @IsNotEmpty({ message: "Tín chỉ tích lũy không được để trống" })
    tctl: string

    @IsNotEmpty({ message: "Tổng số môn đã học không được để trống" })
    tmdh: string

}
