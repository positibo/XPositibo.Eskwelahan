using XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules.Base;

namespace XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules
{
    public class UsernamePasswordIncorrectException : BusinessRulesException
    {
        private const string message = "Username or password is incorrect.";

        public UsernamePasswordIncorrectException() : base(System.Net.HttpStatusCode.BadRequest, message) { }

    }
}
