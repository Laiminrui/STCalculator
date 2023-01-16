using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// 这里的数据要稍微独立一点，因为不一定会采用，尽量不要影响到其他计算数据，全部搬过来这里处理。
    /// </summary>
    public partial class ItemEditForm : Form
    {
        //存储各系统的数据
        DataTable ATSDT = new DataTable();
        DataTable CIDT = new DataTable();
        DataTable ATPDT = new DataTable();
        DataTable DCSDT = new DataTable();
        public ItemEditForm()
        {
            InitializeComponent();
        }

        private void ItemEditForm_Load(object sender, EventArgs e)
        {
            //这里开始进行数据的处理
            ATSDT = CreatDts(GlobalDataTable.SheetNames[0]);
            CIDT = CreatDts(GlobalDataTable.SheetNames[1]);
            ATPDT = CreatDts(GlobalDataTable.SheetNames[2]);
            DCSDT = CreatDts(GlobalDataTable.SheetNames[3]);
            //数据源的绑定
            ATSdataGridView.DataSource = ATSDT;
            CIdataGridView.DataSource = CIDT;
            ATPdataGridView.DataSource = ATPDT;
            DCSdataGridView.DataSource = DCSDT;
            //不允许用户添加新行
            ATSdataGridView.AllowUserToAddRows = false;
            CIdataGridView.AllowUserToAddRows = false;
            ATPdataGridView.AllowUserToAddRows = false;
            DCSdataGridView.AllowUserToAddRows = false;

        }

        /// <summary>
        /// 这里创造界面显示的datagridview的数据源datatable
        /// </summary>
        /// <returns></returns>
        private DataTable Creatdt()
        {
            DataTable dt = new DataTable();
            //foreach()
            return dt;
        }

        /// <summary>
        /// 数据
        /// </summary>
        /// <returns></returns>
        private DataTable CreatDts(string sheetname)
        {
            List<DataTable> dts = new List<DataTable>();
            DataTable dt = new DataTable();
            var ecs = GlobalDataTable.ImportContents.Where(e => e.SheetName == sheetname).ToList();//先不考虑效率问题了，
            dt.TableName = string.Format("系统-{0}", sheetname);
            dt.Columns.Add("工作项", typeof(string));
            dt.Columns.Add("工作内容", typeof(string));
            for (int j = 0; j < GlobalDataTable.CoeficientList.Count; j++)
            {
                dt.Columns.Add(GlobalDataTable.CoeficientList[j].Name, typeof(string));
            }
            dt.Columns.Add("备注", typeof(string));
            foreach (var e in ecs)
            {
                DataRow dr = dt.NewRow();
                dr["工作项"] = e.WorkItem;
                dr["工作内容"] = e.WorkContent;
                for (int k = 0; k < GlobalDataTable.CoeficientList.Count; k++)
                {
                    dr[GlobalDataTable.CoeficientList[k].Name] = GlobalDataTable.CoeficientList[k].Value;
                }
                dr["备注"] = e.Remark;
                dt.Rows.Add(dr);
            }
            return dt;
        }



        private void Confirmbutton_Click(object sender, EventArgs e)
        {
            GlobalDataTable.SingleCoefficientData.Merge(ATSDT);
            GlobalDataTable.SingleCoefficientData.Merge(CIDT);
            GlobalDataTable.SingleCoefficientData.Merge(ATPDT);
            GlobalDataTable.SingleCoefficientData.Merge(DCSDT);
            this.Close();
        }
    }
}
