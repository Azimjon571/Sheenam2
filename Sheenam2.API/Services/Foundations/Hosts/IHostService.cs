//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System.Threading.Tasks;
using Sheenam2.API.Models.Foundation.Hosts;

namespace Sheenam2.API.Services.Foundations.Hosts
{
    public interface IHostService
    {
        ValueTask<Host>AddHostAsync(Host host);
    }
}
