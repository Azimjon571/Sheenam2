//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sheenam2.API.Models.Foundation.Hosts;
using Xunit;

namespace Sheenam2.Api.Tests.Unit.Services.Foundations.Hosts
{
    public partial class HostServiceTests
    {
        [Fact]
        public async Task ShouldAddHostAsync()
        {
            //given
            Host randomHost = CreateRandomHost();
            Host inputHost = randomHost;
            Host storageHost = inputHost;
            Host expectedHost = storageHost.DeepClone();

            this.storageBrokermock.Setup(broker =>
                broker.InsertHostAsync(inputHost))
                    .ReturnsAsync(storageHost);

            //when
            Host actualHost =
                await this.hostService.AddHostAsync(inputHost);

            //then
            actualHost.Should().BeEquivalentTo(expectedHost);

            this.storageBrokermock.Verify(broker=>
                broker.InsertHostAsync(storageHost),
                    Times.Once);

            this.storageBrokermock.VerifyNoOtherCalls();
            this.loggingBrokermock.VerifyNoOtherCalls();
        }
    }
}
