using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
//using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Calculator.WorkContent;

namespace Calculator
{
    public delegate double CoeCal(double orignaltime, double coevalue);
    /// <summary>
    /// 核心计算功能，包含数据处理等
    /// </summary>
    internal class CalCore
    {
        //基本参数，这里在coefficient窗口配置，先统一定一个常数，之后如果深入的话应该是每一行内容都对应一组数据
        public double WorkPercent = 0;//工作时间占比，这里采用小数点，即0.8为80%
        public double MarginPercent = 0;//宽裕系数
        public double AdditionTime = 0;//附加时间

        //先以ATS为例开始计算，ATS专业主要就是这三个参数
        public double StationNum = 0;//车站数量
        public double BlockNum = 0;//区间数量
        public double CIBlockNum = 0;//联锁区数量


        /// <summary>
        /// 构造函数,先这样吧
        /// </summary>
        /// <param name="workPercent">工作时间占比</param>
        /// <param name="marginPercent">宽裕时间系数</param>
        /// <param name="additionTime">附加时间</param>
        /// <param name="stationNum">车站数量</param>
        /// <param name="blockNum">区间数量</param>
        /// <param name="cIBlockNum">联锁区数量</param>
        public CalCore(double workPercent, double marginPercent, double additionTime, double stationNum, double blockNum, double cIBlockNum)
        {
            WorkPercent = workPercent;
            MarginPercent = marginPercent;
            AdditionTime = additionTime;
            StationNum = stationNum;
            BlockNum = blockNum;
            CIBlockNum = cIBlockNum;
        }

        /// <summary>
        /// 根据上面的参数计算最终工时，单位是人*时
        /// </summary>
        /// <returns>最终工时</returns>
        public double CalculateTime(List<WorkContent.ImportContent> ic,out List<WorkContent.ExportContent> ec)
        {
            double TotalTime = 0;
            ec= new List<WorkContent.ExportContent>();
            DataTable ExportDt= new DataTable();//输出的DataTable
            Dictionary<string, double> coedic = new Dictionary<string, double>();//用来存储系数
            for (int i = 0; i < GlobalDataTable.CoeficientList.Count; i++)//整理系数信息
            {
                coedic.Add(GlobalDataTable.CoeficientList[i].Name, GlobalDataTable.CoeficientList[i].Value);
            }
            for (int i = 0; i < ic.Count; i++)//对其中的每条数据进行遍历计算
            {
                double SingleDataTatolTime = 1;//单条数据的总时间
                double BeforeCoeCalTime = 0;//未乘系数的工时
                //主要思路是判断单位的构成，然后乘相应的参数值
                for (int j = 0; j < ic[i].Unite.Count;j++)//遍历单位数量
                {
                    double UniteParameter = GlobalDataTable.UniteTypeParameter[ic[i].Unite[j].Item1];
                    SingleDataTatolTime = ic[i].Unite[j].Item2 *UniteParameter* SingleDataTatolTime;//乘了参数，还没乘系数
                    BeforeCoeCalTime = SingleDataTatolTime;
                }
                //这里需要先提前弄一下系数的输入，靠人工编辑，从外部输入
                //在外部输入数据后开始计算系数
                if (GlobalDataTable.SingleCoefficientData.Rows.Count != 0)//单独配置过了
                {
                    string content = ic[i].WorkContent;
                    string str = "工作内容 = '" + content + "'";
                    var iemcoelist = GlobalDataTable.SingleCoefficientData.Select(str);
                    for (int k = 0; k < GlobalDataTable.CoeficientList.Count; k++)
                    {
                        string coestr = BeforeCoeCalTime == 0 ? "不计算" : GlobalDataTable.CoeficientList[k].type;
                        
                        SingleDataTatolTime = SingleCalCoe(SingleDataTatolTime, coestr, double.Parse(iemcoelist[0][k+2].ToString()));//经过系数计算后的值
                    }
                }
                else
                {
                    //这里已经三重循环了，从效率的角度上说肯定不行，之后肯定要改
                    //这里是没有单独配置，那么系统就会全部填取默认值
                    for (int k = 0; k < GlobalDataTable.CoeficientList.Count; k++)
                    {
                        string coestr = BeforeCoeCalTime == 0 ? "不计算" : GlobalDataTable.CoeficientList[k].type;
                        SingleDataTatolTime = SingleCalCoe(SingleDataTatolTime, coestr, GlobalDataTable.CoeficientList[k].Value);//经过系数计算后的值
                    }
                }
                SingleDataTatolTime = Math.Round(SingleDataTatolTime, 2, MidpointRounding.AwayFromZero);//保留两位小数
                TotalTime += SingleDataTatolTime;
                //同时做一下输出格式,输出格式只需要DataTable类型就行，整合几个列表即可
                #region 输出内容的整理，这里估计有点长，包一下
                string SheetName = ic[i].SheetName;
                string WorkItem = ic[i].WorkItem;
                int WorkItemOrder = 0;
                string WorkContent = ic[i].WorkContent;
                string MixUniteStr = "";//把所有计量单位合并
                string OrignalUnite = ic[i].OrignalUnite;
                //这里做一个处理工作，处理单位填0的

                //
                foreach (var u in ic[i].Unite)
                {
                    MixUniteStr += GlobalDataTable.UniteTypeParameter[u.Item1] + u.Item1 + "/";//u的格式时List<(string,double)>，使用“/”将各单位分开，这是单元数量
                }
                MixUniteStr = MixUniteStr.Remove(MixUniteStr.Length - 1, 1);//去掉最后一个“/”
                string Workload = ic[i].OrignalUnite;//输入的工作量原字符串
                //系数已经在循环前填好
                //单条的最终工时前面有，就是SingleDataTatolTime
                string RisConditon = ic[i].RisCondition;
                string OutPut = ic[i].Output;
                string Remark = ic[i].Remark;
                ExportContent _ec = new ExportContent(SheetName, WorkItem, WorkItemOrder, WorkContent, MixUniteStr, OrignalUnite,
                    BeforeCoeCalTime, coedic, SingleDataTatolTime, RisConditon, OutPut, Remark);//新建一个对象
                ec.Add(_ec);
                #endregion
            }
            return TotalTime;
        }

        public double CoefficientCalculation(double oritime, CoeCal cc, double coevalue)
        {
            return cc(oritime, coevalue);
        }

        /// <summary>
        /// 加操作
        /// </summary>
        /// <param name="oritime"></param>
        /// <param name="coevalue"></param>
        /// <returns></returns>
        public double CalculationPlus(double oritime,double coevalue)
        {
            return oritime + coevalue;
        }

        /// <summary>
        /// 减操作
        /// </summary>
        /// <param name="oritime"></param>
        /// <param name="coevalue"></param>
        /// <returns></returns>
        public double CalculationMinus(double oritime, double coevalue)
        {
            return oritime - coevalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oritime"></param>
        /// <param name="coevalue"></param>
        /// <returns></returns>
        public double CalculationMultiply(double oritime, double coevalue)
        {
            return oritime * coevalue;
        }

        /// <summary>
        /// 除操作
        /// </summary>
        /// <param name="oritime"></param>
        /// <param name="coevalue"></param>
        /// <returns></returns>
        public double CalculationDivid(double oritime, double coevalue)
        {
            if (coevalue == 0)
            {
               MessageBox.Show("有个除相关系数为0，计算无效，请重新填写");
            }
            return oritime/coevalue;
        }

        /// <summary>
        /// 幂操作，coevalue为次数
        /// </summary>
        /// <param name="oritime"></param>
        /// <param name="coevalue"></param>
        /// <returns></returns>
        public double CalculationPower(double oritime, double coevalue)
        {
            return Math.Pow(oritime, coevalue);
        }

        /// <summary>
        /// 取对数操作,coevalue为底
        /// </summary>
        /// <param name="oritime"></param>
        /// <param name="coevalue"></param>
        /// <returns></returns>
        public double CalculationLogarithm(double oritime, double coevalue)
        {
            return Math.Log(oritime, coevalue);
        }

        public double SingleCalCoe(double oritime,string type,double coevalue)
        {
            double SingleDataTatolTime = oritime;
            switch (type)
            {
                case "加":
                    SingleDataTatolTime = CoefficientCalculation(SingleDataTatolTime, CalculationPlus, coevalue);
                    break;
                case "减":
                    SingleDataTatolTime = CoefficientCalculation(SingleDataTatolTime, CalculationMinus, coevalue);
                    break;
                case "乘":
                    SingleDataTatolTime = CoefficientCalculation(SingleDataTatolTime, CalculationMultiply, coevalue);
                    break;
                case "除":
                    SingleDataTatolTime = CoefficientCalculation(SingleDataTatolTime, CalculationDivid, coevalue);
                    break;
                case "幂":
                    SingleDataTatolTime = CoefficientCalculation(SingleDataTatolTime, CalculationPower, coevalue);
                    break;
                case "对数":
                    SingleDataTatolTime = CoefficientCalculation(SingleDataTatolTime, CalculationLogarithm, coevalue);
                    break;
                case "不计算":
                    break;
                default:
                    break;
            }
            return SingleDataTatolTime;
        }

    }
}
