//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using Sheenam2.API.Models.Foundation.Guests;
using Sheenam2.API.Models.Foundation.Guests.Exceptions;

namespace Sheenam2.API.Services.Foundations.Guests
{
    public partial class GuestService
    {
        public void ValidateGuestNotnull(Guest guest)
        {
            if (guest is null)
            {
                throw new NullGuestException();
            }
        }
    }
}
