using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Beyondbit.OA.Common
{
    /// <summary>
    /// ������֤��
    /// </summary>
    public sealed class CheckFunction
    {

        /// <summary>
        /// ��֤�Ƿ�Ϊ������
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsInteger(object obj)
        {
            if (null == obj) return false;
            Regex rx = new Regex("^[0-9]\\d*$");
            bool result = false;
            try
            {
                if (rx.IsMatch(obj.ToString()))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception)
            {
                result = false;
                return result;
            }
            finally
            {
#if DEBUG
                //System.Diagnostics.Debug.Assert(result, "Fnc.IsInteger('" + obj.ToString() + "') return False");
#endif
            }
        }
    }
}
