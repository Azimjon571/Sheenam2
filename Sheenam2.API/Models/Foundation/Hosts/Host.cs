using System;

namespace Sheenam2.API.Models.Foundation.Hosts
{
    public class Host
    {
        public Guid Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public GenderType Gender { get; set; }
    }
}
