using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.OleDb;

//using NPOI;
//using NPOI.HPSF;
//using NPOI.HSSF;
//using NPOI.HSSF.UserModel;
//using NPOI.POIFS;
//using NPOI.Util;
//using System.Text;
//using System.Configuration;

namespace WindowsContronlDemov0._0._1
{
    class Excel
    {
        //public static DataTable RenderFromExcel<T>(Stream excelFileStream) where T : new()
        //{
        //    using (excelFileStream)
        //    {
        //        using (IWorkbook workbook = new HSSFWorkbook(excelFileStream))
        //        {
        //            using (ISheet sheet = workbook.GetSheetAt(0))//取第一个表
        //            {
        //                DataTable table = new DataTable();
        //                IRow headerRow = sheet.GetRow(0);//第一行为标题行
        //                int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells
        //                int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1
        //                                                //定义存取DB字段名称的数组
        //                String[] strArrayHeader = new String[cellCount - headerRow.FirstCellNum];
        //                //定义数组所需用的索引值
        //                int intArrayIndex = 0;
        //                //handling header.得到Excel导入文件的标题行字符串数组
        //                for (int i = 0; i < strArrayHeader.Length; i++)
        //                {
        //                    strArrayHeader[intArrayIndex] = headerRow.GetCell(i).StringCellValue;
        //                    ++intArrayIndex;
        //                }
        //                //调用方法，将标题行文字描述转换为对应的属性名称
        //                strArrayHeader = ConfigOperater.QueryImportEntityProperty<T>(strArrayHeader);
        //                intArrayIndex = 0;
        //                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
        //                {
        //                    //DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
        //                    DataColumn column = new DataColumn(strArrayHeader[intArrayIndex]);
        //                    table.Columns.Add(column);
        //                    ++intArrayIndex;
        //                }
        //                for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
        //                {
        //                    IRow row = sheet.GetRow(i);
        //                    DataRow dataRow = table.NewRow();
        //                    if (row != null)
        //                    {
        //                        for (int j = row.FirstCellNum; j < cellCount; j++)
        //                        {
        //                            if (row.GetCell(j) != null)
        //                                dataRow[j] = GetCellValue(row.GetCell(j));
        //                        }
        //                    }
        //                    table.Rows.Add(dataRow);
        //                }
        //                return table;
        //            }
        //        }
        //    }
        //}
        //public static DataSet ExcelToDS(string Path)
        //{
        //    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "DataSource=" + Path + ";ExtendedProperties=Excel8.0;";
        //    OleDbConnection conn = new OleDbConnection(strConn);
        //    OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT*FROM[Sheet1$]", strConn);
        //    DataSetmyDataSet = newDataSet();
        //    try
        //    {
        //        myCommand.Fill(myDataSet);
        //    }
        //    catch (Exceptionex)
        //    {
        //        throw new InvalidFormatException("该Excel文件的工作表的名字不正确," + ex.Message);
        //    }
        //    return myDataSet;
        //}

        public static DataSet GetExcelToDataTableBySheet(string FileFullPath, string SheetName)
        {
            //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + FileFullPath + ";Extended Properties='Excel 8.0; HDR=NO; IMEX=1'"; //此連接只能操作Excel2007之前(.xls)文件
            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + FileFullPath + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'"; //此連接可以操作.xls與.xlsx文件
            OleDbConnection OleConn = new OleDbConnection(strConn);
            OleConn.Open();
            String sql = "SELECT * FROM [Route_Signal_进路信号机$]";
            //可是更改Sheet名称，比如sheet2，等等  
            OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
            DataSet OleDsExcle = new DataSet();
            OleDaExcel.Fill(OleDsExcle, "Route_Signal_进路信号机");
            OleConn.Close();

            Console.WriteLine(OleDsExcle.Tables[0].Rows[0][0]);
            return OleDsExcle;

        }
    }
}
