//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using Xeptions;

namespace Sheenam2.API.Models.Foundation.Guests.Exceptions
{
    public class GuestDependencyException: Xeption
    {
        public GuestDependencyException(Xeption innerException)
            :base(message:"Guest dependency error occurd, contact support",
                 innerException)
        {}
    }
}
