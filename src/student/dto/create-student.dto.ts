import { IsNotEmpty } from "class-validator"

export class CreateStudentDto {
    @IsNotEmpty({ message: "Mssv không được để trống" })
    mssv: string

    @IsNotEmpty({ message: "Tên không được để trống" })
    name: string

    @IsNotEmpty({ message: "Giới tính không được để trống" })
    gender: string

    @IsNotEmpty({ message: "Ngày sinh không được để trống" })
    birthday: string

    @IsNotEmpty({ message: "Nơi sinh không được để trống" })
    birthplace: string

    @IsNotEmpty({ message: "Lớp không được để trống" })
    class: string

    @IsNotEmpty({ message: "Ngành không được để trống" })
    sector: string
}
