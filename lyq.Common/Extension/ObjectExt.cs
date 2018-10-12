using System;
using System.Linq;

namespace lyq.Common.Extension
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ObjectExt
    {
        public static int ConvertToIntBaseZero(this object o)
        {
            int intRtn = 0;

            if (o != null)
            {
                int.TryParse(o.ToString(), out intRtn);
            }

            return intRtn;
        }

        public static int ConvertToIntBaseNegativeOne(this object o)
        {
            int intRtn = -1;

            if (o != null && o.ToString() != string.Empty)
            {
                int.TryParse(o.ToString(), out intRtn);
            }

            return intRtn;
        }

        public static decimal ConvertToDecimalBaseMinValue(this object o)
        {
            decimal decRtn = decimal.MinValue;

            if (o == null || o == DBNull.Value)
            {
                decRtn = decimal.MinValue;
            }
            else
            {
                if (!decimal.TryParse(o.ToString(), out decRtn))
                {
                    decRtn = decimal.MinValue;
                }
            }

            return decRtn;
        }

        public static bool ConvertToBool(this object o)
        {
            bool bolRtn = false;

            try
            {
                if (o != null && o != DBNull.Value)
                {
                    string str = o.ToString().ToLower();

                    string[] trueStrings = new string[] { "true", "yes", "1", "√", "Y", "T", "是", "对" };

                    if (trueStrings.Contains(str))
                    {
                        bolRtn = true;
                    }
                }
            }
            catch
            {
            }

            return bolRtn;
        }

        public static string ConvertToString(this object o, string replaceString)
        {
            string strRtn = "";

            if (o == null || o == DBNull.Value)
            {
                strRtn = replaceString;
            }
            else
            {
                strRtn = o.ToString();
            }

            return strRtn;
        }

        public static decimal ConvertToDecimal(this object o)
        {
            decimal decRtn = 0m;

            if (o == null || o == DBNull.Value)
            {
                decRtn = 0m;
            }
            else
            {
                decimal.TryParse(o.ToString(), out decRtn);
            }

            return decRtn;
        }

        public static string ConvertToString(this object o)
        {
            return ConvertToString(o, string.Empty);
        }

        public static DateTime ConvertToDateTime(this object o)
        {
            DateTime dtRtn = DateTime.MinValue;

            try
            {
                if (o != null)
                {
                    DateTime.TryParse(o.ToString(), out dtRtn);
                }
            }
            catch
            {
            }

            return dtRtn;
        }
    }
}