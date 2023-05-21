//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using Xeptions;

namespace Sheenam2.API.Models.Foundation.Guests.Exceptions
{
    public class GuestDependencyValidationException : Xeption
    {
        public GuestDependencyValidationException(Xeption innerExeption)
            : base(message: "Guest dependency error occurred, fix the errors and try again ", innerExeption)
        { }
    }
}
