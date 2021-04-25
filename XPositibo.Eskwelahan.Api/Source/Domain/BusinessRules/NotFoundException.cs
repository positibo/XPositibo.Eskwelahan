using System.Net;
using XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules.Base;

namespace XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules
{
    public class NotFoundException : BusinessRulesException
    {
        private const string message = "Record Not Found.";

        public NotFoundException() : base(HttpStatusCode.NotFound, message) { }
    }
}
