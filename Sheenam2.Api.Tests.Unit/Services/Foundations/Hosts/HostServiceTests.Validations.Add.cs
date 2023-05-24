//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================


using Moq;
using Sheenam2.API.Models.Foundation.Guests.Exceptions;
using Sheenam2.API.Models.Foundation.Guests;
using Sheenam2.API.Models.Foundation.Hosts;
using Sheenam2.API.Models.Foundation.Hosts.Exceptions;
using Sheenam2.API.Services.Foundations.Hosts;
using Xunit;

namespace Sheenam2.Api.Tests.Unit.Services.Foundations.Hosts
{
    public partial class HostServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationOnAddIfHostInvalidAndLogItAsync()
        {
            Host nullHost = null;
            var nulHostException = new NullHostException();

            var expectedHostValidatioNException =
                new HostValidationException1(nulHostException);

            //when
            ValueTask<Host> addHostTask =
                this.hostService.AddHostAsync(nullHost);

            //then
            await Assert.ThrowsAsync<HostValidationException1>(() =>
                addHostTask.AsTask());

            this.loggingBrokermock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedHostValidatioNException))),
                        Times.Once);

            this.storageBrokermock.Verify(broker =>
                broker.InsertHostAsync(It.IsAny<Host>()),
                    Times.Never);

            this.loggingBrokermock.VerifyNoOtherCalls();
            this.storageBrokermock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowExceptionOnAddIfHostIsInvalidAndLogItAsync(string invalidData)
        {
            // given
            Host invalidHost = new Host()
            {
                LastName = invalidData
            };

            var invalidHostException = new InvalidHostException();

            invalidHostException.AddData(
                key: nameof(invalidHost.Id), 
                values: "Id is required");

            invalidHostException.AddData(
                key: nameof(invalidHost.FistName), 
                values: "Text is required");

            invalidHostException.AddData(
                key: nameof(invalidHost.LastName), 
                values: "Text is required");

            invalidHostException.AddData(
                key: nameof(invalidHost.DateOfBirth), 
                values: "Date is required");

            invalidHostException.AddData(
                key: nameof(invalidHost.Email), 
                values: "Text is required");

            var hostValidationException =
                new HostValidationException1(invalidHostException);

            // when
            ValueTask<Host> AddHostTask =
                this.hostService.AddHostAsync(invalidHost);

            // then
            await Assert.ThrowsAsync<HostValidationException1>(() =>
                AddHostTask.AsTask());

            this.loggingBrokermock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    hostValidationException))),
                     Times.Once);

            this.storageBrokermock.Verify(broker =>
                broker.InsertHostAsync(It.IsAny<Host>()),
                    Times.Never);

            this.storageBrokermock.VerifyNoOtherCalls();
            this.loggingBrokermock.VerifyNoOtherCalls();
        }
    }
}
