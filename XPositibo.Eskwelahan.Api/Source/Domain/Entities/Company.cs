using System.Collections.Generic;

namespace XPositibo.Eskwelahan.Api.Source.Domain.Entities
{
    public class Company
    {
        public Company()
        {
            Members = new HashSet<Member>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
