//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using Xeptions;

namespace Sheenam2.API.Models.Foundation.Hosts.Exceptions
{
    public class HostValidationException1:Xeption
    {
        public HostValidationException1(Xeption innerException)
            :base(message:"Host validation error occurred, fix the error and try again",
                 innerException)
        {}
    }
}
