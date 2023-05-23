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
    public class HostService : IHostService
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

        public async ValueTask<Host> AddHostAsync(Host host)
        {
            try
            {
                if (host is null)
                {
                    throw new NullHostException();
                }
                return await this.storageBroker.InsertHostAsync(host);
            }
            catch (NullHostException nullHostException)
            {
                var hostValidationException1 = 
                    new HostValidationException1(nullHostException);

                this.loggingBroker.LogError(hostValidationException1);

                throw hostValidationException1;
            }
        }
    }
}
