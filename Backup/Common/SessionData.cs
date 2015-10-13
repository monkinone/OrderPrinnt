using System;
using System.Collections;
using System.Text;
using System.Web.SessionState;

namespace Beyondbit.OA.Common
{
    /// <summary>
    /// π´”√Session¿‡
    /// </summary>
    [Serializable]
    public class SessionData
    {
        private const string C_SESSION_OBJ_KEY = "SESSION_KEY";

        private Hashtable hstSessionData;

        private const string C_MODULE_NAME = "CSessionData";

        public SessionData()
        {
            hstSessionData = Hashtable.Synchronized(new Hashtable());
        }

        public object GetSessionData(string strKey)
        {
            object objReturnValue;

            if (null == strKey)
            {
                throw new ArgumentNullException("Key is null");
            }

            if (null == hstSessionData)
            {
                hstSessionData = Hashtable.Synchronized(new Hashtable());
            }

            objReturnValue = hstSessionData[strKey];

            return objReturnValue;
        }

        public void SetSessionData(string strKey, object objValue)
        {
            if (strKey == null)
            {
                throw new ArgumentNullException("Key is null");
            }

            hstSessionData[strKey] = objValue;

            return;
        }


        public void Clear()
        {
            this.hstSessionData.Clear();
        }

        public void Remove(string strKey)
        {
            if (strKey == null)
            {
                throw new ArgumentNullException("Key is null");
            }

            if (hstSessionData == null)
            {
                return;
            }

            hstSessionData.Remove(strKey);

            return;
        }

        public static SessionData GetInstance(HttpSessionState obj)
        {
            if (null != obj[C_SESSION_OBJ_KEY])
            {
                return (SessionData)obj[C_SESSION_OBJ_KEY];
            }
            else
            {
                obj.Add(C_SESSION_OBJ_KEY, new SessionData());
                return (SessionData)obj[C_SESSION_OBJ_KEY];
            }
        }
    }
}
