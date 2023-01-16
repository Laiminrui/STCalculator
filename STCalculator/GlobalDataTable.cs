using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class GlobalDataTable
    {
        /// <summary>
        /// 全局的输入数据列表
        /// </summary>
        public static DataTable ImportDt = new DataTable();//全局的数据列表

        /// <summary>
        /// 全局的输出数据列表
        /// </summary>
        public static DataTable ExportDt = new DataTable();

        /// <summary>
        /// 这里装输入内容
        /// </summary>
        public static List<WorkContent.ImportContent> ImportContents = new List<WorkContent.ImportContent>();//这里装输入内容

        /// <summary>
        /// 这里装入从标准库读取的单位信息，如<"信号机",13>表示信号机有13架，需要进行两步操作：
        /// <1>在读取标准库后建立对应的字典
        /// <2>在参数输入窗口进行赋值
        /// </summary>
        public static Dictionary<string, double> UniteTypeParameter = new Dictionary<string, double>();//这里存单位的类型和参数,

        /// <summary>
        /// 这里存系数的信息
        /// </summary>
        public static List<string[]> CoeString= new List<string[]>();

        /// <summary>
        /// 系数存储
        /// </summary>
        public static BindingList<CoefficientEditForm.T> CoeficientList = new BindingList<CoefficientEditForm.T>();

        /// <summary>
        /// 输出数据列表（系数未处理）
        /// </summary>
        public static List<WorkContent.ExportContent> exportContents;//= new List<WorkContent.ExportContent>();

        /// <summary>
        /// 存储工作簿名称
        /// </summary>
        public static List<string> SheetNames = new List<string>();


        /// <summary>
        /// 单独进行了系数配置的data列表
        /// </summary>
        public static DataTable SingleCoefficientData = new DataTable();
    }
}
