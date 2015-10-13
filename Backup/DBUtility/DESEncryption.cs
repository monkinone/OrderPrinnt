/************************************************************************************
 *      Copyright (C) 2008 Newer SoftFactory,All Rights Reserved					*
 *      File:																		*
 *				DESEncryption.cs                                                    *
 *      Description:																*
 *				加密解密工具                       								    *
 *      Author:																		*
 *				  														        *
 *				a_hui												*
 *      Finish DateTime:															*
 *				2009年11月6日														*
 
 *                                                       *
 ************************************************************************************/

using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
 
using System.Text;
using System.IO;

namespace Util
{
    public class DESEncryption
    {
        public DESEncryption()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
          
        }


        /// <summary>
        /// 密钥,已经赋默认值,可改
        /// </summary>
        private static string key64 = "LIUZHONG"; //八位

        /// <summary>
        /// 密钥,已经赋默认值,可改
        /// </summary>
        private static string iv64 = "LIUZHONG";   //八位

        /// <summary>
        /// 公钥
        /// </summary>
        public string Key64
        {
            get { return key64; }
            set { key64 = value; }
        }

        /// <summary>
        /// 私钥
        /// </summary>
        public string Iv64
        {
            get { return iv64; }
            set { iv64 = value; }
        }


        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="data">要加密的字符串</param>
        /// <param name="tmpKey64">公钥</param>
        /// <param name="tmpIv64">私钥</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string data, string tmpKey64, string tmpIv64)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(tmpKey64);
            byte[] byIv = System.Text.ASCIIEncoding.ASCII.GetBytes(tmpIv64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIv), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="data">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key64);
            byte[] byIv = System.Text.ASCIIEncoding.ASCII.GetBytes(iv64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIv), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="data">要解密的字符串</param>
        /// <param name="tmpKey64">公钥</param>
        /// <param name="tmpIv64">私钥</param>
        /// <returns>解密后的字符串</returns>
        public static String Decrypt(string data, string tmpKey64, string tmpIv64)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(tmpKey64);
            byte[] byIv = System.Text.ASCIIEncoding.ASCII.GetBytes(tmpIv64);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIv), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="data">要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public static String Decrypt(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key64);
            byte[] byIv = System.Text.ASCIIEncoding.ASCII.GetBytes(iv64);
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIv), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }
    }
}
