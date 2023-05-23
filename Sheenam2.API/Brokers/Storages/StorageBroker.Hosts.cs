//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using Microsoft.EntityFrameworkCore;
using Sheenam2.API.Models.Foundation.Hosts;

namespace Sheenam2.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Host> Hosts { get; set; }
    }
}
