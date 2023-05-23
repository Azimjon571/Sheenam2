//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using Xeptions;

namespace Sheenam2.API.Models.Foundation.Hosts.Exceptions
{
    public class InvalidHostException:Xeption
    {
        public InvalidHostException()
            :base(message:"Host is invalid")
        {}
    }
}
