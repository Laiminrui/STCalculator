using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using BorderStyle = NPOI.SS.UserModel.BorderStyle;
using NPOI.OpenXmlFormats.Spreadsheet;
using System.IO;
using System.Windows.Forms;

public delegate DataTable ImportExcelFile(ISheet sheet);//委托，导入excel表格数据  
namespace Calculator
{
    internal class DataConnect
    {

        /// <summary>
        /// 这一个DataTable囊括了所有的内容，通过里面的SheetName来区分
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExportExcelAllSheet(DataTable dt1, string name)
        {
            try
            {
                //表1
                IWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet(dt1.TableName);
                ICellStyle cellStyle = book.CreateCellStyle();
                cellStyle.BorderTop = BorderStyle.Thin;
                cellStyle.BorderRight = BorderStyle.Thin;
                cellStyle.BorderBottom = BorderStyle.Thin;
                cellStyle.BorderLeft = BorderStyle.Thin;

                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt1.Columns.Count; i++)
                {
                    row.CreateCell(i).SetCellValue(dt1.Columns[i].ColumnName);
                    row.GetCell(i).CellStyle = cellStyle;

                }
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    IRow r = sheet.CreateRow(i + 1);
                    var items = dt1.Rows[i].ItemArray;
                    int k = 0;
                    for (int j = 0; j < items.Length; i++)
                    {
                        r.CreateCell(k).SetCellValue(items[k] as string);
                        r.GetCell(k).CellStyle = cellStyle;
                    }
                    for (int j = 0; j < GlobalDataTable.CoeficientList.Count; j++)
                    {
                        r.CreateCell(j).SetCellValue(GlobalDataTable.CoeficientList[j].Value);
                        r.GetCell(k).CellStyle = cellStyle;
                    }
                }

                System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
                dialog.Filter = "Excel files(*.xlsx)|*.xlsx";
                dialog.FileName = name;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FileStream file = new FileStream(dialog.FileName, FileMode.Create);
                    book.Write(file);//搞清楚这个leaveopen的参数含义
                    file.Close();
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //AssistanceFunctions.log.LogWrite(e);//记录异常
                return false;
            }
            return true;
        }



        /// <summary>
        /// 导入excel文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="ief">传进来的导入方法</param>
        /// <returns></returns>
        public static bool ImportExcel(string filepath, ImportExcelFile ief, out DataTable dt)
        {
            try
            {
                IWorkbook workbook;
                string extension = System.IO.Path.GetExtension(filepath);//获取excel文件的扩展名
                FileStream fs = File.OpenRead(filepath);
                if (extension.Equals(".xls"))
                {
                    workbook = new HSSFWorkbook(fs);//把xls文件中的数据写入workbook中
                }
                else
                {
                    workbook = new XSSFWorkbook(fs);//把xlsx文件中的数据写入workbook中
                }
                fs.Close();
                ISheet sheet = workbook.GetSheetAt(0);
                dt = ief(sheet);//根据按钮传进来的导入函数的不同，读取方式也不同
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                dt = null;
                return false;
            }
            return true;
        }

        public static bool ImportExcelSheets(string filepath, ImportExcelFile ief, out DataTable dt)
        {
            //try
            //{
                IWorkbook workbook;
                string extension = System.IO.Path.GetExtension(filepath);//获取excel文件的扩展名
                FileStream fs = File.OpenRead(filepath);
                if (extension.Equals(".xls"))
                {
                    workbook = new HSSFWorkbook(fs);//把xls文件中的数据写入workbook中
                }
                else
                {
                    workbook = new XSSFWorkbook(fs);//把xlsx文件中的数据写入workbook中
                }
                fs.Close();
                int SheetCount = workbook.NumberOfSheets;//这里是工作簿的数量
                //List<ISheet> sheets = new List<ISheet>();//这里存储每页工作簿的内容
                dt = new DataTable();//这里新建一下
                for (int i = 0; i < SheetCount; i++)
                {
                    ISheet _isheet = workbook.GetSheetAt(i);//每个工作簿的内容
                    dt.Merge(ief(_isheet));//datatable合并            
                }
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //    dt = null;
            //    return false;
            //}
            return true;
        }


        /// <summary>
        /// 导入标准工时库内容
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static DataTable ImportStandardDataExcel(ISheet sheet)
        {
            DataTable dt = new DataTable();
            int NotEmptyCellCount = 0;
            dt.TableName = "标准工时库";//这里定义表头
            dt.Columns.Add("专业名称",typeof(string));//工作簿名称
            dt.Columns.Add("工作项", typeof(string));
            dt.Columns.Add("工作内容", typeof(string));
            dt.Columns.Add("工作量", typeof(string));
            dt.Columns.Add("限制条件", typeof(string));
            dt.Columns.Add("产出", typeof(string));
            dt.Columns.Add("备注", typeof(string));

            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)//将每一行数据导入到DataTable中
            {
                DataRow dr = dt.NewRow();
                var item = sheet.GetRow(i);
                //NotEmptyCellCount = item.FirstCellNum;
                if (item.GetCell(NotEmptyCellCount) == null)
                    break;
                dr["专业名称"] = sheet.SheetName;
                dr["工作项"] = item.GetCell(NotEmptyCellCount);
                dr["工作内容"] = item.GetCell(NotEmptyCellCount + 1);
                dr["工作量"] = item.GetCell(NotEmptyCellCount + 2);
                dr["限制条件"] = item.GetCell(NotEmptyCellCount + 3);
                dr["产出"] = item.GetCell(NotEmptyCellCount + 4);
                dr["备注"] = item.GetCell(NotEmptyCellCount + 5);
                if (dr["工作项"].ToString() == "" && dr["工作内容"].ToString() == "" && dr["工作量"].ToString() == "" && dr["限制条件"].ToString() == "" && dr["产出"].ToString() == "" && dr["备注"].ToString() == "")
                    continue;
                else
                    dt.Rows.Add(dr);
            }
            return dt;
        }



        /// <summary>
        /// 导出EXCEL（单表）
        /// </summary>
        /// <param name="dt">表</param>
        /// <param name="name">默认文件名</param>
        /// <returns></returns>
        public static bool ExportExcel(DataTable dt, string name)
        {
            try
            {
                IWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet(dt.TableName);
                int rownum = 0;
                ICellStyle cellStyle = book.CreateCellStyle();
                cellStyle.BorderTop = BorderStyle.Thin;
                cellStyle.BorderRight = BorderStyle.Thin;
                cellStyle.BorderBottom = BorderStyle.Thin;
                cellStyle.BorderLeft = BorderStyle.Thin;

                IRow row = sheet.CreateRow(rownum++);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                    row.GetCell(i).CellStyle = cellStyle;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow r = sheet.CreateRow(i + rownum);
                    var items = dt.Rows[i].ItemArray;
                    int k = 0;
                    foreach (var str in items)
                    {
                        r.CreateCell(k).SetCellValue(str as string);
                        r.GetCell(k).CellStyle = cellStyle;

                        k++;
                    }
                }
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Excel files(*.xlsx)|*.xlsx";
                dialog.FileName = name;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //AssistanceFunctions.log.LogWrite(e);//记录异常
                return false;
            }
            return true;
        }
    }    
}
