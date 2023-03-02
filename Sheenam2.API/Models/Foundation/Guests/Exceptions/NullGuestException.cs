//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using Xeptions;

namespace Sheenam2.API.Models.Foundation.Guests.Exceptions
{
    public class NullGuestException : Xeption
    {
        public NullGuestException()
            : base(message: "Guest is null")
        { }
    }
}
