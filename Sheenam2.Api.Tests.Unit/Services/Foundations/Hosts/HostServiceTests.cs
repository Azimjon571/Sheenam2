//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using Moq;
using Sheenam2.API.Brokers.Loggings;
using Sheenam2.API.Brokers.Storages;
using Sheenam2.API.Models.Foundation.Hosts;
using Sheenam2.API.Services.Foundations.Hosts;
using Tynamix.ObjectFiller;

namespace Sheenam2.Api.Tests.Unit.Services.Foundations.Hosts
{
    public partial class HostServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokermock;
        private readonly Mock<ILoggingBroker> loggingBrokermock;
        private readonly IHostService hostService;

        public HostServiceTests()
        {
            this.storageBrokermock = new Mock<IStorageBroker>();
            this.loggingBrokermock = new Mock<ILoggingBroker>();

            this.hostService = new HostService(
                   storageBroker: this.storageBrokermock.Object,
                   loggingBroker: this.loggingBrokermock.Object);
        }

        private static Host CreateRandomHost() =>
            CreateHostFiller(date: GetRandomDateTineOffSet()).Create();

        private static DateTimeOffset GetRandomDateTineOffSet() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();
        private static Filler<Host> CreateHostFiller(DateTimeOffset date)
        {
            var filler = new Filler<Host>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
