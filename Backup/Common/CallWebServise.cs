using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web.Services.Description;
using System.CodeDom;
using System.Net;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Runtime.Remoting.Messaging;

namespace Beyondbit.OA.Common
{
    public class CallWebServise
    {
        delegate object MyMethodDelegate(string url, string classname, string methodname, object[] args);

        /// <summary>
        /// ��̬����WebService
        /// </summary>
        /// <param name="url">WebService��ַ</param>
        /// <param name="methodname">������(ģ����)</param>
        /// <param name="args">�����б�</param>
        /// <returns>object</returns>
        public static void InvokeWebService(string url, string methodname, object[] args)
        {
            MyMethodDelegate my_delegate = new MyMethodDelegate(CallWebServise.InvokeWebServiceNew);
            my_delegate.BeginInvoke(url, null, methodname, args, null, null);

            //  return InvokeWebService(url, null, methodname, args);
        }
        /// <summary>
        /// ��̬����WebService
        /// </summary>
        /// <param name="url">WebService��ַ</param>
        /// <param name="classname">����</param>
        /// <param name="methodname">������(ģ����)</param>
        /// <param name="args">�����б�</param>
        /// <returns>object</returns>
        public static object InvokeWebServiceNew(string url, string classname, string methodname, object[] args)
        {
            string @namespace = "ServiceBase.WebService.DynamicWebLoad";
            if (classname == null || classname == "")
            {
                classname = CallWebServise.GetClassName(url);
            }
            //��ȡ������������(WSDL)
            WebClient wc = new WebClient();
            Stream stream = wc.OpenRead(url + "?WSDL");
            ServiceDescription sd = ServiceDescription.Read(stream);

            ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
            sdi.AddServiceDescription(sd, "", "");

            CodeNamespace cn = new CodeNamespace(@namespace);
            //���ɿͻ��˴������
            CodeCompileUnit ccu = new CodeCompileUnit();
            ccu.Namespaces.Add(cn);
            sdi.Import(cn, ccu);


            CSharpCodeProvider csc = new CSharpCodeProvider();
            ICodeCompiler icc = csc.CreateCompiler();

            //�趨�������Ĳ���
            CompilerParameters cplist = new CompilerParameters();
            cplist.GenerateExecutable = false;
            cplist.GenerateInMemory = true;
            cplist.ReferencedAssemblies.Add("System.dll");
            cplist.ReferencedAssemblies.Add("System.XML.dll");
            cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
            cplist.ReferencedAssemblies.Add("System.Data.dll");
            //���������
            CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);

            if (true == cr.Errors.HasErrors)
            {
                System.Text.StringBuilder sb = new StringBuilder();
                foreach (CompilerError ce in cr.Errors)
                {
                    sb.Append(ce.ToString());
                    sb.Append(System.Environment.NewLine);
                }
                throw new Exception(sb.ToString());
            }

            //���ɴ���ʵ��,�����÷���
            System.Reflection.Assembly assembly = cr.CompiledAssembly;
            Type t = assembly.GetType(@namespace + "." + classname, true, true);
            object obj = Activator.CreateInstance(t);
            System.Reflection.MethodInfo mi = t.GetMethod(methodname);
            return mi.Invoke(obj, args);

        }

        private static string GetClassName(string url)
        {
            string[] parts = url.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');
            return pps[0];
        }

    }
}
