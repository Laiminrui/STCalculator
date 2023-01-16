using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Calculator
{
    public partial class CoefficientEditForm : Form
    {
        public enum CalType { 加 = 1, 减, 乘, 除, 开方, 幂, 对数 }

        public BindingList<T> ts;


        public CoefficientEditForm()
        {
            InitializeComponent();
        }

        private void CoefficientEditForm_Load(object sender, EventArgs e)
        {
            GridViewInit();
        }

        /// <summary>
        /// 对DatagridView进行初始化操作
        /// </summary>
        private void GridViewInit()
        {
            if (GlobalDataTable.CoeficientList.Count != 0)
            {
                CoedataGridView.DataSource = GlobalDataTable.CoeficientList;
                CoedataGridView.AllowUserToAddRows = false;
            }
            else
            {
                ts = new BindingList<T>();
                //ts.Add(new T());
                CoedataGridView.DataSource = ts;
                CoedataGridView.AllowUserToAddRows = false;
            }
            DataGridViewComboBoxColumn myCombo = new DataGridViewComboBoxColumn();
            myCombo.DataSource = new CalType[] { CalType.加, CalType.减, CalType.乘, CalType.除, CalType.幂, CalType.对数 };
            myCombo.HeaderText = "计算类型";
            myCombo.Name = "CalType";
            myCombo.ValueType = typeof(CalType);
            myCombo.DataPropertyName = "CalType";
            CoedataGridView.Columns.Add(myCombo);
        }

        private void NewRowsbutton_Click(object sender, EventArgs e)
        {
            ts.AddNew();
        }

        private void Confirmbutton_Click(object sender, EventArgs e)
        {
            GlobalDataTable.CoeficientList.Clear();
            //这里写确认后的操作
            for (int i = 0; i < CoedataGridView.RowCount; i++)
            {
                T temp = new T(int.Parse(CoedataGridView.Rows[i].Cells[0].Value.ToString()), CoedataGridView.Rows[i].Cells[1].Value.ToString(),
                    double.Parse(CoedataGridView.Rows[i].Cells[2].Value.ToString()), CoedataGridView.Rows[i].Cells[3].Value.ToString());//这里新建了内容，没有类型
                temp.type = CoedataGridView.Rows[i].Cells[4].Value.ToString();//这里赋值计算类型
                GlobalDataTable.CoeficientList.Add(temp);                
            }
            this.Close();
        }

        private void Cancalbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        public class T
        {
            private  int index = 1;
            private string name;
            private double coevalue;           
            public string type;
            private string remark;
            public static int LastIndex = 0;
            public T(int _index, string _name, double _coevalue, string _remark)
            {
                index = _index;
                name = _name;
                coevalue = _coevalue;
                remark = _remark;
            }
            public T()
            {

                index = ++LastIndex;
                name = "";
                coevalue = 0;
                remark = "无";
                type = "加";
            }

            public int Index { get { return index; } set { index = value; } }
            public string Name { get { return name; } set { name = value; } }
            public double Value { get { return coevalue; } set { coevalue = value; } }
            //public CalType Type { get { return type; } set { type = value; } }
            public string Remark { get { return remark; } set { remark = value; } }


        }
    }
}