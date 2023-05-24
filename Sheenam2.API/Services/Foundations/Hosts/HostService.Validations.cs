//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================


using System;
using Sheenam2.API.Models.Foundation.Hosts;
using Sheenam2.API.Models.Foundation.Hosts.Exceptions;

namespace Sheenam2.API.Services.Foundations.Hosts
{
    public partial class HostService
    {
        private  void ValidateHostOnAdd(Host host)
        {
            ValidateHostNotNull(host);

            Validate(

                (Rule: IsInvalid(host.Id), Parameter: nameof(Host.Id)),
                (Rule: IsInvalid(host.FistName), Parameter: nameof(Host.FistName)),
                (Rule: IsInvalid(host.LastName), Parameter: nameof(Host.LastName)),
                (Rule: IsInvalid(host.DateOfBirth), Parameter: nameof(Host.DateOfBirth)),
                (Rule: IsInvalid(host.Email), Parameter: nameof(Host.Email)));
        }
        private void ValidateHostNotNull(Host host)
        {
            if (host is null)
            {
                throw new NullHostException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition=id==Guid.Empty,
            Message="Id is requared"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition=string.IsNullOrWhiteSpace(text),
            Message="Text is requared"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message="Date is requared"
        };



        private static void Validate(params(dynamic Rule, string Parameter)[] validation)
        {
            var invalidHostException = new InvalidHostException();
                        
            foreach ((dynamic rule, string paramenet) in validation)
            {
                if (rule.Condition)
                {
                    invalidHostException.UpsertDataList(
                        key: paramenet,
                        value: rule.Message);
                }
            }
            invalidHostException.ThrowIfContainsErrors();
        }
    }
}
