//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System;
using Xeptions;

namespace Sheenam2.API.Models.Foundation.Guests.Exceptions
{
    public class FailedGuestStorageException:Xeption
    {
        public FailedGuestStorageException(Exception innerException)
            :base(message:"Failed Guest storage error occurred, contact support",innerException)
        {}
    }
}
