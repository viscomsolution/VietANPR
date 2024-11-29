//CÔNG TY TNHH GIẢI PHÁP THỊ GIÁC MÁY TÍNH
//support@viscomsolution.com
//0939.825.125


//To install EPPlus to handle excel file, go to menu in Visual Studio: Tools -> NuGet Package Manager -> Package Manager Console
//Type following in console:
//PM> Install-Package EPPlus


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using OfficeOpenXml.Style;
using System.Windows.Forms;
using OfficeOpenXml.Table;

namespace TGMTcs
{
    public class TGMTexcel
    {
        ExcelPackage m_excel;
        ExcelWorkbook m_workbook;

        

        public TGMTexcel(string fileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                m_excel = new ExcelPackage(new FileInfo(fileName));
                m_workbook = m_excel.Workbook;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Save()
        {
            m_excel.Save();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SaveAs(string fileName)
        {
            m_excel.SaveAs(new FileInfo(fileName));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetCellValue(int worksheetID, int row, int col,  string value)
        {
            m_workbook.Worksheets[worksheetID].Cells[row, col].Value = value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetFormat(int worksheetID, int row, int col, Color bgcolor, Color foreColor, bool bold = false)
        {
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Fill.BackgroundColor.SetColor(bgcolor);
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Font.Color.SetColor(foreColor);
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Font.Bold = bold;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetCellTextColor(int worksheetID, int row, int col, Color foreColor)
        {
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Font.Color.SetColor(foreColor);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetCellAlignment(int worksheetID, int row, int col, ExcelHorizontalAlignment hAlign = ExcelHorizontalAlignment.Center, ExcelVerticalAlignment vAlign = ExcelVerticalAlignment.Center)
        {            
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.HorizontalAlignment = hAlign;
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.VerticalAlignment = vAlign;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //column ID begin at 1
        public void SetAutoFitContent(int worksheetID, int col)
        {
            m_workbook.Worksheets[worksheetID].Column(col).AutoFit();            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddRow(int worksheetID, int row, string[] values)
        {
            for(int i=0; i<values.Length;i++)
            {
                m_workbook.Worksheets[worksheetID].Cells[row, i+ 1].Value = values[i];
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddSheet(string sheetName)
        {
            if(m_workbook.Worksheets[sheetName] == null)
                m_workbook.Worksheets.Add(sheetName);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetTitle(int worksheetID, int row, int col, string value)
        {
            SetCellValue(worksheetID, row, col, value);
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Font.Bold = true;
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Font.Size = 20;


            string range = (char)('A' + col) + row.ToString() + ":" + (char)('A' + col + 4) + row.ToString();
            m_workbook.Worksheets[worksheetID].Cells[range].Merge = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DrawTable(int worksheetID, int fromRow, int fromCol, int toRow, int toCol)
        {
            //var FirstTableRange = m_workbook.Worksheets[worksheetID].Cells[fromRow, fromCol, toRow, toCol];
            //FirstTableRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            //FirstTableRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            //FirstTableRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            //FirstTableRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            ExcelWorksheet ws = m_workbook.Worksheets[worksheetID];
            //create a range for the table
            ExcelRange range = ws.Cells[1, 1, toRow, toCol];
            //add a table to the range
            //ExcelTable tab = ws.Tables.Add(range, "Table1");
        }
    }


}
