//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================


using Sheenam2.API.Models.Foundation.Hosts;
using Sheenam2.API.Models.Foundation.Hosts.Exceptions;

namespace Sheenam2.API.Services.Foundations.Hosts
{
    public partial class HostService
    {
        private void ValidateHostNotNull(Host host)
        {
            if (host is null)
            {
                throw new NullHostException();
            }
        }
    }
}
