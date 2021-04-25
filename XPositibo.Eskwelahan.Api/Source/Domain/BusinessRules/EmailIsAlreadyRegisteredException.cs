using XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules.Base;

namespace XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules
{
    public class EmailIsAlreadyRegisteredException : BusinessRulesException
    {
        private const string message = "Email is already registered";

        public EmailIsAlreadyRegisteredException() : base(System.Net.HttpStatusCode.BadRequest, message) { }
    }
}
