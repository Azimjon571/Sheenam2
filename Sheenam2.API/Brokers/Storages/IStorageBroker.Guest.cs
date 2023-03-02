//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System.Threading.Tasks;
using Sheenam2.API.Models.Foundation.Guests;

namespace Sheenam2.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Guest> InsertGuestAsync(Guest guest);
    }
}

