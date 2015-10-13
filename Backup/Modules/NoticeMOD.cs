using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
    public class NoticeMOD
    {
        private int _noticeId;
        private string _title;
        private string _contents;
        /// <summary>
        /// 内容
        /// </summary>
        public string Contents
        {
            get { return _contents; }
            set { _contents = value; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// 通知id
        /// </summary>
        public int NoticeId
        {
            get { return _noticeId; }
            set { _noticeId = value; }
        }
    }
}
