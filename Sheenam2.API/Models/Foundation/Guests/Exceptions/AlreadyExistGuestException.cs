//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System;
using Xeptions;

namespace Sheenam2.API.Models.Foundation.Guests.Exceptions
{
    public class AlreadyExistGuestException:Xeption
    {
        public AlreadyExistGuestException(Exception innerException)
            : base(message: "Guest already exist", innerException)
        {}
    }
}
