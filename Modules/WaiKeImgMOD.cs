using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
   public class WaiKeImgMOD
    {
        private int _imgId;
        private string _waiKeNo;
        private string _waiKeImg;
        private int _isModify;
       /// <summary>
       /// 是否修改了标示图片
       /// </summary>
        public int IsModify
        {
            get { return _isModify; }
            set { _isModify = value; }
        }
       /// <summary>
       /// 外壳图片
       /// </summary>
        public string WaiKeImg
        {
            get { return _waiKeImg; }
            set { _waiKeImg = value; }
        }
       /// <summary>
       /// 外壳编号
       /// </summary>
        public string WaiKeNo
        {
            get { return _waiKeNo; }
            set { _waiKeNo = value; }
        }
       /// <summary>
       /// 外壳id
       /// </summary>
        public int ImgId
        {
            get { return _imgId; }
            set { _imgId = value; }
        }
    }
}
