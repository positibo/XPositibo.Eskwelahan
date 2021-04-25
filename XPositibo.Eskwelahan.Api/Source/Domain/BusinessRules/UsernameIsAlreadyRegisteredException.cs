using System.Net;
using XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules.Base;

namespace XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules
{
    public class UsernameIsAlreadyRegisteredException : BusinessRulesException
    {
        private const string message = "Username is already registered";

        public UsernameIsAlreadyRegisteredException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
