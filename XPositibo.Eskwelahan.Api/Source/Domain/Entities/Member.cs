using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XPositibo.Eskwelahan.Api.Source.Domain.Entities
{
    public class Member
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
