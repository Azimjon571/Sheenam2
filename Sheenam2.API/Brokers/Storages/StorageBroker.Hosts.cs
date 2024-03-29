﻿//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sheenam2.API.Models.Foundation.Hosts;

namespace Sheenam2.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Host> Hosts { get; set; }

        public async ValueTask<Host> InsertHostAsync(Host host)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Host> hostEntityEntry = 
                await broker.Hosts.AddAsync(host);

            await broker.SaveChangesAsync();

            return hostEntityEntry.Entity;

        }
    }
}
