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
    public partial class ParameterEditForm : Form
    {
        public ParameterEditForm()
        {
            InitializeComponent();

            //dataGridView1.DataSource = GlobalDataTable.UniteTypeParameter.ToList();//这里绑定数据源
            DataGridViewLoad();
        }

        private void ParameterEditForm_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = GlobalDataTable.UniteTypeParameter;
        }


        private void DataGridViewLoad()
        {
            var ParameterList= GlobalDataTable.UniteTypeParameter.ToList();
            dataGridView1.RowCount = ParameterList.Count + 1;//建立行
            //dataGridView1.ColumnCount = 2;//建立列
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = ParameterList[i].Key.ToString();//赋值单位名称
                this.dataGridView1.Rows[i].Cells[1].Value = ParameterList[i].Value.ToString();//赋值单位数量
            }
            //设置一些必要属性
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Rows[0].Cells[1].ReadOnly = true;//将人和h定为只读，此处有个逻辑bug，如何保证人和h在前两位？
                                                           //虽然大部分情况是对的，但是有例外先码住
            dataGridView1.Rows[1].Cells[1].ReadOnly = true;//将人和h定为只读
            dataGridView1.AllowUserToAddRows = false;//禁止用户添加行
            //dataGridView1.AllowUserToDeleteRows = false;//禁止用户删除行
        }

        /// <summary>
        /// 在确定键按下后，开始修改之前的参数
        /// </summary>
        private void ChangeParameter()
        {
            Dictionary<string, double> u = new Dictionary<string, double>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                u.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString())) ;
            }
            GlobalDataTable.UniteTypeParameter = u;//重新赋值修改过的单位参数
        }

        /// <summary>
        /// 取消参数修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确认参数修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditConfirmbutton_Click(object sender, EventArgs e)
        {
            ChangeParameter();  
            this.Close();
        }
    }
}
