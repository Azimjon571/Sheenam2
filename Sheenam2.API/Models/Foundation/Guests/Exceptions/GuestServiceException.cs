//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using Xeptions;

namespace Sheenam2.API.Models.Foundation.Guests.Exceptions
{
    public class GuestServiceException:Xeption
    {
        public GuestServiceException(Xeption innerException)
            :base(message:"Guest service error occurred, contact support",innerException)
        {}
    }
}
