using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGMT;

namespace ExampleVietANPR
{
    class Program
    {
        static void Main(string[] args)
        {
            //Đầu tiên khai báo biến dùng để đọc biển số, chỉ khai báo 1 lần
            PlateReader reader = new PlateReader();

            //Đọc biển số từ đường dẫn ảnh, kết quả trả về là class chứa các thông tin về biển số
            VehiclePlate[] plates = reader.Reads("2019-03-25.06-12-14.jpg");

            for(int i=0; i<plates.Length; i++)
            {
                VehiclePlate plate = plates[i];

                //Thuộc tính text chứa ký biển số, alphanumeric là text loại bỏ ký tự đặc biệt
                Console.WriteLine(plate.text + " (" + plate.alphanumeric + ")" );


                //dừng chương trình để xem kết quả
                Console.ReadLine();
            }
        }
    }
}
