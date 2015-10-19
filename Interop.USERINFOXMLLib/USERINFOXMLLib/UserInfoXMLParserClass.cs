namespace USERINFOXMLLib
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, ClassInterface((short) 0), TypeLibType((short) 2), Guid("37D58321-E206-4CD7-85F9-F114921C3164")]
    public class UserInfoXMLParserClass : IUserInfoXMLParser, UserInfoXMLParser
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(1)]
        public virtual extern int BJCA_Initialize([In, MarshalAs(UnmanagedType.BStr)] string XMLFileString, [In, MarshalAs(UnmanagedType.BStr)] string ApplicationMode, [In, MarshalAs(UnmanagedType.BStr)] string SenderCertificate, [In, MarshalAs(UnmanagedType.BStr)] string svrContainerName, [In, MarshalAs(UnmanagedType.BStr)] string keyPasswd);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(12)]
        public virtual extern void BJCA_ShutDown();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(9)]
        public virtual extern string GetCurrentUserRoleCodeByIndex([In, MarshalAs(UnmanagedType.BStr)] string CurrentUserRoleIndex);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(7)]
        public virtual extern string GetCurrentUserRoleCounter();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(8)]
        public virtual extern string GetCurrentUserRoleNameByIndex([In, MarshalAs(UnmanagedType.BStr)] string UserRoleIndex);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(13)]
        public virtual extern string GetErrorMessage();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(11)]
        public virtual extern string GetExtraInfoByIndex([In, MarshalAs(UnmanagedType.BStr)] string ExtraInfoIndex);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(14)]
        public virtual extern string GetExtraInfoByItemName([In, MarshalAs(UnmanagedType.BStr)] string ExtraItemName);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(10)]
        public virtual extern string GetExtraInfoCounter();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(4)]
        public virtual extern string GetUserCredenceType();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(5)]
        public virtual extern string GetUserDepartmentCode();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(6)]
        public virtual extern string GetUserSystemCode();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(3)]
        public virtual extern string GetUserType();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(2)]
        public virtual extern string GetUserUniqueID();
    }
}

