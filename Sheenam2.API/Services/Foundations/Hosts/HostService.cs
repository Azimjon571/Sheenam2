//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System.Threading.Tasks;
using Sheenam2.API.Brokers.Loggings;
using Sheenam2.API.Brokers.Storages;
using Sheenam2.API.Models.Foundation.Hosts;
using Sheenam2.API.Models.Foundation.Hosts.Exceptions;

namespace Sheenam2.API.Services.Foundations.Hosts
{
    public partial class HostService : IHostService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public HostService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker=storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Host> AddHostAsync(Host host) =>
        TryCatch(async () =>
        {
            ValidateHostNotNull(host);

            return await this.storageBroker.InsertHostAsync(host);
        });
    }
}
