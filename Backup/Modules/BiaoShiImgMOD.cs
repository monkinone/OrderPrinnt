using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
   public class BiaoShiImgMOD
    {
        private int _imgId;
        private string _biaoShiNo;
        private string _biaoShiImg;
       /// <summary>
       /// 标示图片
       /// </summary>
        public string BiaoShiImg
        {
            get { return _biaoShiImg; }
            set { _biaoShiImg = value; }
        }
       /// <summary>
       /// 标示位置编号
       /// </summary>
        public string BiaoShiNo
        {
            get { return _biaoShiNo; }
            set { _biaoShiNo = value; }
        }
       /// <summary>
       /// 主键id
       /// </summary>
        public int ImgId
        {
            get { return _imgId; }
            set { _imgId = value; }
        }
    }
}
