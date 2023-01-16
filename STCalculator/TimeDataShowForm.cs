using Calculator;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BorderStyle = NPOI.SS.UserModel.BorderStyle;

namespace STCalculator
{
    public partial class TimeDataShowForm : Form
    {
        private double ATSToltalTime;
        private double CITotalTime;
        private double ATPTotalTime;
        private double DCSToltalTime;
        private List<double> TimeList;
        public TimeDataShowForm()
        {
            InitializeComponent();
        }

        private void OutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FilePath = "";
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Multiselect = false;//不允许选择多个文件
            dialog.Title = "请选择导入的文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            DataTable dt = new DataTable();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FilePath = dialog.FileName;
                //DataConnect.ImportExcel(FilePath, DataConnect.ImportStandardDataExcel, out dt);
                DataConnect.ImportExcelSheets(FilePath, DataConnect.ImportStandardDataExcel, out dt);
                //DataHandle d = new DataHandle();
                DataHandle.ImportDataHandle(dt);
                MessageBox.Show("导入成功");
            }
        }

        private void ParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParameterEditForm PEForm = new ParameterEditForm();
            PEForm.ShowDialog();
        }

        private void CoefficientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoefficientEditForm CEForm = new CoefficientEditForm();
            CEForm.ShowDialog();
        }

        private void SetSingleCoefficientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemEditForm ief = new ItemEditForm();
            ief.ShowDialog();
        }

        /// <summary>
        /// 计算按钮，计算（由计算类实现）并存储（窗口实现）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalCore cal = new CalCore(0.8, 0.2, 1, 18, 23, 5);//测试
            List<WorkContent.ImportContent> ic = new List<WorkContent.ImportContent>();//建立输入内容
            //DataHandle.ImportDataHandle(GlobalDataTable.ImportDt);
            //GlobalDataTable.UniteTypeParameter尚未赋值
            double t = cal.CalculateTime(GlobalDataTable.ImportContents, out GlobalDataTable.exportContents);
            var atsmess = GlobalDataTable.exportContents.Where(ec => ec.SheetName == GlobalDataTable.SheetNames[0]).ToList();
            double atstime = Math.Round(atsmess.Sum(ec => ec.TotalTime), 2, MidpointRounding.AwayFromZero);
            var cimess = GlobalDataTable.exportContents.Where(ec => ec.SheetName == GlobalDataTable.SheetNames[1]).ToList();
            double citime = Math.Round(cimess.Sum(ec => ec.TotalTime), 2, MidpointRounding.AwayFromZero);
            var atpmess = GlobalDataTable.exportContents.Where(ec => ec.SheetName == GlobalDataTable.SheetNames[2]).ToList();
            double atptime = Math.Round(atpmess.Sum(ec => ec.TotalTime), 2, MidpointRounding.AwayFromZero);
            var dcsmess = GlobalDataTable.exportContents.Where(ec => ec.SheetName == GlobalDataTable.SheetNames[3]).ToList();
            double dcstime = Math.Round(dcsmess.Sum(ec => ec.TotalTime), 2, MidpointRounding.AwayFromZero);
            t = Math.Round(t, 2, MidpointRounding.AwayFromZero);//保留两位小数
            //制作dt的时候用
            TimeList = new List<double>();
            TimeList.Add(atstime);
            TimeList.Add(citime);
            TimeList.Add(atptime);
            TimeList.Add(dcstime);
            //界面显示用
            ATSlabel.Text = atstime.ToString();
            CIlabel.Text = citime.ToString();
            ATPlabel.Text = atptime.ToString();
            DCSlabel.Text = dcstime.ToString();
            Toltallabel.Text = t.ToString();
            MessageBox.Show("计算完成，总时间" + t.ToString() + "小时");
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string LineName = "模拟线路2";
            bool finish = ExportExcel(CreatDts(), LineName);
            if (!finish)
            {
                MessageBox.Show("excel导出失败");
            }
            else
                MessageBox.Show("EXCEL导出成功");
        }

        private void VisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("0.4");
        }


        /// <summary>
        /// 导出EXCEL（单表）
        /// </summary>
        /// <param name="dt">表</param>
        /// <param name="name">默认文件名</param>
        /// <returns></returns>
        public static bool ExportExcel(List<DataTable> dts, string name)
        {
            //try
            //{
            IWorkbook book = new XSSFWorkbook();
            for (int i = 0; i < dts.Count; i++)
            {
                ISheet sheet = book.CreateSheet(dts[i].TableName);
                int rownum = 0;
                ICellStyle cellStyle = book.CreateCellStyle();
                cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderRight = BorderStyle.Thin;
                cellStyle.BorderBottom = BorderStyle.Thin;
                cellStyle.BorderLeft = BorderStyle.Thin;
                IRow row = sheet.CreateRow(rownum++);
                for (int j = 0; j < dts[i].Columns.Count; j++)//注意，dts后面填i，其余的填j
                {
                    row.CreateCell(j).SetCellValue(dts[i].Columns[j].ColumnName);
                    row.GetCell(j).CellStyle = cellStyle;
                }
                for (int j = 0; j < dts[i].Rows.Count; j++)
                {
                    IRow r = sheet.CreateRow(j + rownum);
                    var items = dts[i].Rows[j].ItemArray;
                    int k = 0;
                    foreach (var str in items)
                    {
                        r.CreateCell(k).SetCellValue(str as string);
                        r.GetCell(k).CellStyle = cellStyle;
                        k++;
                    }
                }
            }

            //SaveFileDialog dialog = new SaveFileDialog();
            //dialog.Filter = "Excel files(*.xlsx)|*.xlsx";
            //dialog.FileName = name;
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = "Excel files(*.xlsx)|*.xlsx";
            dialog.FileName = name;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream file = new FileStream(dialog.FileName, FileMode.Create);
                book.Write(file);
                file.Close();
            }
            else
                return false;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //    //AssistanceFunctions.log.LogWrite(e);//记录异常
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// 建立输出的dt
        /// </summary>
        /// <returns></returns>
        private List<DataTable> CreatDts()
        {
            List<DataTable> dts = new List<DataTable>();

            for (int i = 0; i < GlobalDataTable.SheetNames.Count; i++)
            {
                DataTable dt = new DataTable();
                var ecs = GlobalDataTable.exportContents.Where(e => e.SheetName == GlobalDataTable.SheetNames[i]).ToList();//先不考虑效率问题了，
                dt.TableName = string.Format("系统-{0}", GlobalDataTable.SheetNames[i]);
                dt.Columns.Add("工作项", typeof(string));
                dt.Columns.Add("工作内容", typeof(string));
                dt.Columns.Add("单元数量", typeof(string));
                dt.Columns.Add("工作量", typeof(string));
                dt.Columns.Add("原始工时", typeof(string));
                for (int j = 0; j < GlobalDataTable.CoeficientList.Count; j++)
                {
                    dt.Columns.Add(GlobalDataTable.CoeficientList[j].Name, typeof(string));
                }
                dt.Columns.Add("最终工时", typeof(string));
                dt.Columns.Add("限制条件", typeof(string));
                dt.Columns.Add("产出", typeof(string));
                dt.Columns.Add("备注", typeof(string));
                foreach (var e in ecs)
                {
                    DataRow dr = dt.NewRow();
                    dr["工作项"] = e.WorkItem;
                    dr["工作内容"] = e.WorkContent;
                    dr["单元数量"] = e.Unite;
                    dr["工作量"] = e.UnitesContent;
                    dr["原始工时"] = e.WorkTime;
                    if (GlobalDataTable.SingleCoefficientData.Rows.Count != 0)//单独配置过了
                    {
                        string content = e.WorkContent;
                        string str = "工作内容 = '" + content + "'";
                        var iemcoelist = GlobalDataTable.SingleCoefficientData.Select(str);
                        for (int k = 0; k < GlobalDataTable.CoeficientList.Count; k++)
                        {
                            dr[GlobalDataTable.CoeficientList[k].Name] = iemcoelist[0][k + 2].ToString();
                        }
                    }
                    else
                    {
                        //这里已经三重循环了，从效率的角度上说肯定不行，之后肯定要改
                        //这里是没有单独配置，那么系统就会全部填取默认值
                        for (int k = 0; k < GlobalDataTable.CoeficientList.Count; k++)
                        {
                            dr[GlobalDataTable.CoeficientList[k].Name] = GlobalDataTable.CoeficientList[k].Value;
                        }
                    }
                    //for (int k = 0; k < GlobalDataTable.CoeficientList.Count; k++)
                    //{
                    //    dr[GlobalDataTable.CoeficientList[k].Name] = GlobalDataTable.CoeficientList[k].Value;
                    //}
                    dr["最终工时"] = e.TotalTime;
                    dr["限制条件"] = e.RisCondition;
                    dr["产出"] = e.Output;
                    dr["备注"] = e.Remark;
                    dt.Rows.Add(dr);
                }
                DataRow adddr = dt.NewRow();
                adddr["最终工时"] = TimeList[i];
                dt.Rows.Add(adddr);
                dts.Add(dt);//给DataTable列表中添加DataTable
            }
            return dts;
        }
    }
}
