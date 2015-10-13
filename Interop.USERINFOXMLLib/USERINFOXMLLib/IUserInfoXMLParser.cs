namespace USERINFOXMLLib
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("14F9C46B-F6C1-4D60-80BD-E423E7A1C7D6"), TypeLibType((short) 0x1040)]
    public interface IUserInfoXMLParser
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(1)]
        int BJCA_Initialize([In, MarshalAs(UnmanagedType.BStr)] string XMLFileString, [In, MarshalAs(UnmanagedType.BStr)] string ApplicationMode, [In, MarshalAs(UnmanagedType.BStr)] string SenderCertificate, [In, MarshalAs(UnmanagedType.BStr)] string svrContainerName, [In, MarshalAs(UnmanagedType.BStr)] string keyPasswd);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(2)]
        string GetUserUniqueID();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(3)]
        string GetUserType();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(4)]
        string GetUserCredenceType();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(5)]
        string GetUserDepartmentCode();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(6)]
        string GetUserSystemCode();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(7)]
        string GetCurrentUserRoleCounter();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(8)]
        string GetCurrentUserRoleNameByIndex([In, MarshalAs(UnmanagedType.BStr)] string UserRoleIndex);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(9)]
        string GetCurrentUserRoleCodeByIndex([In, MarshalAs(UnmanagedType.BStr)] string CurrentUserRoleIndex);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(10)]
        string GetExtraInfoCounter();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(11)]
        string GetExtraInfoByIndex([In, MarshalAs(UnmanagedType.BStr)] string ExtraInfoIndex);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(12)]
        void BJCA_ShutDown();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(13)]
        string GetErrorMessage();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(14)]
        string GetExtraInfoByItemName([In, MarshalAs(UnmanagedType.BStr)] string ExtraItemName);
    }
}

