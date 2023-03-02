//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System.Threading.Tasks;
using Sheenam2.API.Models.Foundation.Guests;

namespace Sheenam2.API.Models.Foundations.Guests
{
    public interface IGuestService
    {
        ValueTask<Guest> AddGuestAsync(Guest guest);
    }
}
