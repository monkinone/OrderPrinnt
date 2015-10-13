using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
   public class GuanJiaoZhenImgMOD
    {
        private int _imgId;
        private string _guanJiaoZhenNo;
        private string _guanJiaoZhenImg;
       /// <summary>
       /// 管脚针图片
       /// </summary>
        public string GuanJiaoZhenImg
        {
            get { return _guanJiaoZhenImg; }
            set { _guanJiaoZhenImg = value; }
        }
       /// <summary>
       /// 管脚针编号
       /// </summary>
        public string GuanJiaoZhenNo
        {
            get { return _guanJiaoZhenNo; }
            set { _guanJiaoZhenNo = value; }
        }
       /// <summary>
       /// 管脚针id
       /// </summary>
        public int ImgId
        {
            get { return _imgId; }
            set { _imgId = value; }
        }
    }
}
