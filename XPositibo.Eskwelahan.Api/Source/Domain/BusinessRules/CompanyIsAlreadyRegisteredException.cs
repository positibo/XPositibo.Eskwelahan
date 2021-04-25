using System.Net;
using XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules.Base;

namespace XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules
{
    public class CompanyIsAlreadyRegisteredException : BusinessRulesException
    {
        private const string message = "Company name is already registered";

        public CompanyIsAlreadyRegisteredException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
