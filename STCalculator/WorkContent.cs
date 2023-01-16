//using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Calculator
{
    internal class WorkContent
    {
        /// <summary>
        /// 工作内容类，输入格式
        /// </summary>
        public class ImportContent
        {
            public string SheetName;//工作簿名称
            public string WorkItem;//工作项
            public int WorkItemOrder;//工作项序号
            public string WorkContent;//工作内容
            public List<(string,double)> Unite;//工作量单位，基本计算单元
            public string RisCondition;//限制条件
            public string Output;//产出
            public string Remark;//备注
            public string OrignalUnite;//原有的工作量单位，记录，之后输出要用

            /// <summary>
            /// 构造函数，读取excel表中的内容，建立工作内容对象
            /// </summary>
            /// <param name="workitem">工作项</param>
            /// <param name="workitemorder">工作项序号</param>
            /// <param name="workcontent">工作内容</param>
            /// <param name="u">工作量单位</param>
            /// <param name="riscondition">限制条件</param>
            /// <param name="output">产出</param>
            /// <param name="remark">备注</param>
            public ImportContent(string sheetname,string workitem, int workitemorder, string workcontent, List<(string,double)> u, string riscondition, string output, string remark, string orignalunit)
            {
                SheetName= sheetname;//工作簿名称
                WorkItem = workitem;//工作项
                WorkItemOrder = workitemorder;//工作项序号
                WorkContent = workcontent;//工作内容
                Unite = u;//工作量单位，基本计算单元
                RisCondition = riscondition;//限制条件
                Output = output;//产出
                Remark = remark;//备注 
                OrignalUnite= orignalunit;//原工作量单位字符串
            }
        }

        public class ExportContent
        {
            public string SheetName;
            public string WorkItem;//工作项
            public int WorkItemOrder;//工作项序号
            public string WorkContent;//工作内容
            public string Unite;//工作量单位，基本计算单元
            public string UnitesContent;//工作量单元内容和数量
            public double WorkTime;//工作用时
            public Dictionary<string, double> CoefficientMess;
            public double TotalTime;//最终工时
            public string RisCondition;//限制条件
            public string Output;//产出
            public string Remark;//备注

            //构造函数
            public ExportContent(string sheetname, string workitem, int workitemorder, string workcontent, string u, string unitescontent, double worktime, Dictionary<string, double> coefficientmess, double totaltime, string riscondition, string output, string remark)
            {
                SheetName = sheetname;
                WorkItem = workitem;//工作项
                WorkItemOrder = workitemorder;//工作项序号
                WorkContent = workcontent;//工作内容
                Unite = u;//工作量单位，基本计算单元
                UnitesContent = unitescontent;//工作量单元内容和数量
                WorkTime = worktime;//工作用时
                CoefficientMess=coefficientmess;//系数信息
                TotalTime = totaltime;//最终工时
                RisCondition = riscondition;//限制条件
                Output = output;//产出
                Remark = remark;//备注 
            }
        }
    }
}
