//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================


using Sheenam2.API.Models.Foundation.Guests;
using Sheenam2.API.Models.Foundation.Guests.Exceptions;
using Xunit;

namespace Sheenam2.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGuestIsNullAndLogItAsync()
        {
            //given
            Guest nullGuest = null;
            var nullGuestException = new NullGuestException();

            var expectedGuestValidationException =
                new GuestValidationException(nullGuestException);

            //when
            ValueTask<Guest> addGuastTask =
                this.guestService.AddGuestAsync(nullGuest);

            //then
            await Assert.ThrowsAsync<GuestValidationException>(() =>
                addGuastTask.AsTask());
        }
    }
}
