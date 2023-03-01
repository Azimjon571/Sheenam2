//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System;
using System.Threading.Tasks;
using Sheenam2.API.Brokers.Storages;
using Sheenam2.API.Models.Foundation.Guests;

namespace Sheenam2.API.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;

        public GuestService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;


        public ValueTask<Guest> AddGuestAsync(Guest guest) =>
            throw new NotImplementedException();

    }
}
