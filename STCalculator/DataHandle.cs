using NPOI.SS.UserModel;
//using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    internal class DataHandle
    {
        public delegate double Method(double time, string CalType);//委托，进行系数计算

        public  class CalType
        {
            public string CalName;
            public double Percent;
            public string Type;
        }

        /// <summary>
        /// 根据读取的DataTable来建立相关的输入数据对象并存储，第一次处理
        /// </summary>
        /// <param name="dt"></param>
        public static void ImportDataHandle(DataTable dt)
        {
            ////这里进行单位初始化，确保“人”和“小时”可以排在前两位
            //GlobalDataTable.UniteTypeParameter.Add("人", 1);
            //GlobalDataTable.UniteTypeParameter.Add("小时", 1);
            //
            for (int i = 0; i < dt.Rows.Count; i++)//从行开始遍历
            {
                var sheetname = dt.Rows[i][0].ToString();
                var item = dt.Rows[i][1].ToString();
                var content = dt.Rows[i][2].ToString();
                var OrignalUnites = dt.Rows[i][3].ToString();
                var risconditon= dt.Rows[i][4].ToString();
                var output = dt.Rows[i][5].ToString();
                var remark = dt.Rows[i][6].ToString();
                //开始处理工作量单位
                List<(string, double)> u = new List<(string, double)>();//
                string[] s = OrignalUnites.Split(new char[2] { '*', '/' });//通过*和/来分割单位
                for (int j = 0; j < s.Count(); j++)
                {
                    if (s[j] == "0")//说明这一行在这条线路项目上是空的
                    {
                        u.Add(("人", 0));//这里除了得考虑相乘还得考虑系数的“加”“减”等操作
                    }
                    else//说明有值，需要计算
                    {
                        string Name = RemoveNumber(s[j]);
                        string NumStr = RemoveNotNumber(s[j]);
                        double Num = NumStr == "" ? 1 : double.Parse(NumStr);
                        if(Name!="")
                            u.Add((Name, Num));//单位名称，数值
                        if (Name != ""&&!GlobalDataTable.UniteTypeParameter.ContainsKey(Name))//排除填0的情况录入单位
                            GlobalDataTable.UniteTypeParameter.Add(Name, 1);//添加一条新的，之前没遇到的单位信息
                        if (!GlobalDataTable.SheetNames.Contains(sheetname))
                            GlobalDataTable.SheetNames.Add(sheetname);//这里存工作簿名称
                    }
                }
                //这里相当于已经录完了所有的单位，对于一条dt信息，已经有了完整的数据，接下来是建立对象并存储
                WorkContent.ImportContent IC = new WorkContent.ImportContent(sheetname, item, 0, content, u, risconditon, output, remark, OrignalUnites);//这里要保证输入参数的非空
                GlobalDataTable.ImportContents.Add(IC);//添加数据
            }           
        }

        /// <summary>
        /// 根据读取的系数进行第二次处理，假设系数靠外部输入List<string,method> 类型和方法
        /// </summary>
        public static void CalDataHandle(double OriSinTime, Method method, List<CalType> calTypes)
        {
            double CaledTime = OriSinTime;
            for (int i = 0; i < calTypes.Count; i++)
            {
                CaledTime = method(CaledTime, calTypes[i].Type);//这里进行不同方式的系数计算
            }
        }

        /// 去掉字符串中的数字
        public static string RemoveNumber(string key)
        {
            return Regex.Replace(key, @"[0-9]+(\.)?", "");
        }
        //去掉字符串中的非数字
        public static string RemoveNotNumber(string key)
        {
            return Regex.Replace(key, @"[^\d]*", "");
        }
    }
}
