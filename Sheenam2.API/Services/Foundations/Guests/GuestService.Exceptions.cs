//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Sheenam2.API.Models.Foundation.Guests;
using Sheenam2.API.Models.Foundation.Guests.Exceptions;
using Xeptions;

namespace Sheenam2.API.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private delegate ValueTask<Guest> ReturningGuestFunction();

        private async ValueTask<Guest> TryCatch(ReturningGuestFunction returningGuestFunction)
        {
            try
            {
                return await returningGuestFunction();
            }
            catch (NullGuestException nullGuestException)
            {
                throw CreateAndLogValidationException(nullGuestException);
            }
            catch (InvalidGuestException invalidGuestException)
            {
                throw CreateAndLogValidationException(invalidGuestException);
            }
            catch(SqlException sqlException)
            {
                var failedGuestStorageException = 
                    new FailedGuestStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedGuestStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistGuestException =
                    new AlreadyExistGuestException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistGuestException);
            }
            catch(Exception exception)
            {
                var failedGuestServiceException = 
                    new FailedGuestServiceException(exception);

                throw CreateAndLogGuestServiceException(failedGuestServiceException);
            }
        }

        private GuestValidationException CreateAndLogValidationException(Xeption exeption)
        {
            var guestValidationException =
                    new GuestValidationException(exeption);

            this.loggingBroker.LogError(guestValidationException);

            return guestValidationException;
        }

        private GuestDependencyException CreateAndLogCriticalDependencyException(Xeption exeption)
        {
            var guestDependencyException =
                new GuestDependencyException(exeption);

            this.loggingBroker.LogCritical(guestDependencyException);

            return guestDependencyException;
        }

        private GuestDependencyValidationException CreateAndLogDependencyValidationException(
            Xeption exception)
        {
            var guestDependencyValidationException =
                new GuestDependencyValidationException(exception);

            this.loggingBroker.LogError(guestDependencyValidationException);

            return guestDependencyValidationException;
        }

        private GuestServiceException CreateAndLogGuestServiceException(Xeption exception)
        {
            var guestServiceException = new GuestServiceException(exception);

            this.loggingBroker.LogError(guestServiceException);

            return guestServiceException;
        }
    }
}
