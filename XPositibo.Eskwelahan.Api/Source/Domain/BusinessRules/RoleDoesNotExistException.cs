using System.Net;
using XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules.Base;

namespace XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules
{
    public class RoleDoesNotExistException : BusinessRulesException
    {
        private const string message = "The role does not exist.";

        public RoleDoesNotExistException() : base(HttpStatusCode.NotFound, message) { }
    }
}
