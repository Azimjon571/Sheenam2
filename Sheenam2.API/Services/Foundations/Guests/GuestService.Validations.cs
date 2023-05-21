﻿//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System;
using Sheenam2.API.Models.Foundation.Guests;
using Sheenam2.API.Models.Foundation.Guests.Exceptions;

namespace Sheenam2.API.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private void ValidateGuestOnAdd(Guest guest)
        {
            ValidateGuestNotnull(guest);


            Validate(
                (Rule: IsInvalid(guest.Id), Parameter: nameof(Guest.Id)),
                (Rule: IsInvalid(guest.FirstName), Parameter: nameof(Guest.FirstName)),
                (Rule: IsInvalid(guest.LastName), Parameter: nameof(Guest.LastName)),
                (Rule: IsInvalid(guest.DateOfBirth), Parameter: nameof(Guest.DateOfBirth)),
                (Rule: IsInvalid(guest.Email), Parameter: nameof(Guest.Email)),
                (Rule: IsInvalid(guest.Address), Parameter: nameof(Guest.Address)),
                (Rule: IsInvalid(guest.Gender), Parameter: nameof(Guest.Gender))
                );
        }
        private void ValidateGuestNotnull(Guest guest)
        {
            if (guest is null)
            {
                throw new NullGuestException();
            }

        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(GenderType gender) => new
        {
            Condition = Enum.IsDefined(gender) is false,
            Message = "Value is invalid"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidGuestException = new InvalidGuestException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidGuestException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidGuestException.ThrowIfContainsErrors();

        }
    }
}
