Imports TGMT

Module Module1

    Sub Main()
        ' Đầu tiên khai báo biến dùng để đọc biển số, chỉ khai báo 1 lần
        Dim reader As New PlateReader()

        ' Đọc biển số từ đường dẫn ảnh, kết quả trả về là class chứa các thông tin về biển số
        Dim plate As PlateInfo = reader.Read("2019-03-25.06-12-14.jpg")

        ' Thuộc tính text chứa ký tự đọc được 
        Console.WriteLine(plate.text)

        ' alphanumeric là text loại bỏ ký tự đặc biệt
        Console.WriteLine(plate.alphanumeric)

        ' dừng chương trình để xem kết quả
        Console.ReadLine()
    End Sub

End Module
