using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace VietANPRdemo
{
    class Plate
    {
        public int index = 0;
        string imagePath = "";
        string text = "";

        public Plate(string _imagePath, string _text)
        {
            imagePath = _imagePath;
            text = _text;
        }

        public string[] ToArray(bool fullPath = true)
        {
            string[] arr = new string[3];
            arr[0] = index.ToString();
            arr[1] = fullPath ? imagePath : Path.GetFileName(imagePath);
            arr[2] = text;
            return arr;
        }
    }
}

