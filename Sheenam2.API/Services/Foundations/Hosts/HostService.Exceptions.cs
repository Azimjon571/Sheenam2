//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System.Threading.Tasks;
using Sheenam2.API.Models.Foundation.Hosts;
using Sheenam2.API.Models.Foundation.Hosts.Exceptions;
using Xeptions;

namespace Sheenam2.API.Services.Foundations.Hosts
{
    public partial class HostService
    {
        private delegate ValueTask<Host> ReturningHostFunction();

        private async ValueTask<Host> TryCatch(ReturningHostFunction returningHostFunction)
        {
            try
            {
                return await returningHostFunction();
            }
            catch (NullHostException nullHostException)
            {
                throw CreateAndLogValidationException(nullHostException);
            }
            catch(InvalidHostException invalidHostException)
            {
                throw CreateAndLogValidationException1(invalidHostException);
            }
        }
        private HostValidationException1 CreateAndLogValidationException(Xeption exception)
        {
            var hostValidationException1 =
                    new HostValidationException1(exception);

            this.loggingBroker.LogError(hostValidationException1);

            return hostValidationException1;
        }

        private HostValidationException1 CreateAndLogValidationException1(Xeption exception)
        {
            var hostValidationException1 =
                new HostValidationException1(exception);

            this.loggingBroker.LogError(hostValidationException1);

            return hostValidationException1;
        }
    }
}
