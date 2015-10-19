using System;
using System.Collections.Generic;
using System.Text;

namespace Beyondbit.OA.Common
{
    public class FormatData
    {
        static string[] HTML_RP_CHAR = {	
										  "&",  "&amp;", 
										  ">",  "&gt;", 
										  "<",  "&lt;", 
										  //	{ "\"", "&quot;" },
										  //	{ "'",  "&apos;" }
										  "\"", "&quot;",
										  " ", "&nbsp;"
									  };

        public static string ReplaceSpecialHtmlWord(string strText)
        {

            if (strText == null || strText.Trim() == string.Empty) return string.Empty;

            for (int i = 0; i < 5; i++)
            {
                string sOValue, sNValue;
                sOValue = HTML_RP_CHAR[i * 2];
                sNValue = HTML_RP_CHAR[i * 2 + 1];
                strText = strText.Replace(sOValue, sNValue);
            }
            strText = strText.Replace("\r\n", "<BR>");
            return strText;
        }

        public static string ReplaceDangerousChar(string Str)
        {
            if (Str == null)
            {
                return "";
            }
            else
            {
                Str = Str.Replace(Convert.ToChar(0).ToString(), "");
                Str = Str.Replace("'", "''"); return Str;
            }
        }
    }
}
