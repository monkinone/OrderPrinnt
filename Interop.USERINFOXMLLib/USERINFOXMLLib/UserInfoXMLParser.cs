namespace USERINFOXMLLib
{
    using System.Runtime.InteropServices;

    [ComImport, Guid("14F9C46B-F6C1-4D60-80BD-E423E7A1C7D6"), CoClass(typeof(UserInfoXMLParserClass))]
    public interface UserInfoXMLParser : IUserInfoXMLParser
    {
    }
}

