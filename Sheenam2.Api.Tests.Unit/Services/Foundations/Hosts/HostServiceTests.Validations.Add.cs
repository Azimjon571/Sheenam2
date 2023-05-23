//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================


using Moq;
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
        public async Task ShouldThrowValidationExseptionOnAddIfHostIsInvalidAndLogItAsync(
            string invalidText)
        {
            //given
            var invalidHost = new Host
            {
                FistName=invalidText
            };
            var invalidHostException = new InvalidHostException();

            invalidHostException.AddData(
                key: nameof(Host.Id),
                values: "Id is required");

            invalidHostException.AddData(
                key: nameof(Host.FistName),
                values: "Text is required");

            invalidHostException.AddData(
                key: nameof(Host.LastName),
                values: "Text is required");

            invalidHostException.AddData(
                key: nameof(Host.DateOfBirth),
                values: "Date is required");

            invalidHostException.AddData(
                key: nameof(Host.Email),
                values: "Text is required");

            var expectedHostValidationException =
                new HostValidationException1(invalidHostException);
            //when
            ValueTask<Host> addHostTask =
                this.hostService.AddHostAsync(invalidHost);

            //then
            await Assert.ThrowsAsync<HostValidationException1>(() =>
                addHostTask.AsTask());

            this.loggingBrokermock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedHostValidationException))),
                        Times.Once);

            this.storageBrokermock.Verify(broker =>
                broker.InsertHostAsync(It.IsAny<Host>()),
                    Times.Never);

            this.loggingBrokermock.VerifyNoOtherCalls();
            this.storageBrokermock.VerifyNoOtherCalls();
        }
    }
}
