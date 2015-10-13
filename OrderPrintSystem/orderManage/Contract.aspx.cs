using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Modules;
using System.Data;

public partial class orderManage_Contract : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            //绑定客户基本信息
            if (Request.QueryString["customerNo"] != null && Request.QueryString["customerNo"].ToString() != "")
            {
                string customerNo = Request.QueryString["customerNo"].ToString();
                CustomerManageMod mod = CustomerManageBLL.GetcustomerByid(customerNo);
                if (mod != null)
                {
                    lblCompanyName.Text = mod.CompanyName;
                    txtAddress.Text = mod.CompanyAddress;
                    txtcontacts.Text = mod.Contacts;
                    txtphone.Text = mod.Phone;
                    txttax.Text = mod.Tax;
                    txttelPhone.Text = mod.TelPhone;
                    lblToName.Text = mod.CompanyName;
                }
            }
            //绑定订单型号
            if (Request.QueryString["orderNum"] != null && Request.QueryString["orderNum"].ToString() != "")
            {
                string orderNum = Request.QueryString["orderNum"].ToString();
                DataSet ds = ProOrdersDetailBLL.GetList(" and orderNum='" + orderNum + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rptPro.DataSource = ds;
                    rptPro.DataBind();
                    //绑定总价
                    string totalPrice = ProOrdersDetailBLL.GetOrderTotalPrice(orderNum);
                    lblTotalPrice.Text = totalPrice.ToString();
                    lblDaxiePrice.Text = CmycurD(Convert.ToDecimal(totalPrice));

                    tabDongTai.Visible = true;
                    tabJingTai.Visible = false;
                }
                else
                {
                    tabDongTai.Visible = false;
                    tabJingTai.Visible = true;
                }
                //订单号
                lblOrderNUM.Text = orderNum;

            }
            else
            {
                tabDongTai.Visible = false;
                tabJingTai.Visible = true;
            }

        }
    }
    /// <summary>
    /// 小写金额转成大写金额
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string CmycurD(decimal num)
    {
        string str1 = "零壹贰叁肆伍陆柒捌玖"; //0-9所对应的汉字 
        string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
        string str3 = ""; //从原num值中取出的值 
        string str4 = ""; //数字的字符串形式 
        string str5 = ""; //人民币大写金额形式 
        int i; //循环变量 
        int j; //num的值乘以100的字符串长度 
        string ch1 = ""; //数字的汉语读法 
        string ch2 = ""; //数字位的汉字读法 
        int nzero = 0; //用来计算连续的零值是几个 
        int temp; //从原num值中取出的值 

        num = Math.Round(Math.Abs(num), 2); //将num取绝对值并四舍五入取2位小数 
        str4 = ((long)(num * 100)).ToString(); //将num乘100并转换成字符串形式 
        j = str4.Length; //找出最高位 
        if (j > 15) { return "溢出"; }
        str2 = str2.Substring(15 - j); //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分 

        //循环取出每一位需要转换的值 
        for (i = 0; i < j; i++)
        {
            str3 = str4.Substring(i, 1); //取出需转换的某一位的值 
            temp = Convert.ToInt32(str3); //转换为数字 
            if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
            {
                //当所取位数不为元、万、亿、万亿上的数字时 
                if (str3 == "0")
                {
                    ch1 = "";
                    ch2 = "";
                    nzero = nzero + 1;
                }
                else
                {
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        ch1 = str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                }
            }
            else
            {
                //该位是万亿，亿，万，元位等关键位 
                if (str3 != "0" && nzero != 0)
                {
                    ch1 = "零" + str1.Substring(temp * 1, 1);
                    ch2 = str2.Substring(i, 1);
                    nzero = 0;
                }
                else
                {
                    if (str3 != "0" && nzero == 0)
                    {
                        ch1 = str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 == "0" && nzero >= 3)
                        {
                            ch1 = "";
                            ch2 = "";
                            nzero = nzero + 1;
                        }
                        else
                        {
                            if (j >= 11)
                            {
                                ch1 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                ch1 = "";
                                ch2 = str2.Substring(i, 1);
                                nzero = nzero + 1;
                            }
                        }
                    }
                }
            }
            if (i == (j - 11) || i == (j - 3))
            {
                //如果该位是亿位或元位，则必须写上 
                ch2 = str2.Substring(i, 1);
            }
            str5 = str5 + ch1 + ch2;

            if (i == j - 1 && str3 == "0")
            {
                //最后一位（分）为0时，加上“整” 
                str5 = str5 + '整';
            }
        }
        if (num == 0)
        {
            str5 = "零元整";
        }
        return str5;
    }
}