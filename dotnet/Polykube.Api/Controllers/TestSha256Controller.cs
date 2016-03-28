using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

using Dotkube.Contracts.V1;

namespace Dotkube.Api.Controllers
{
    [Route("/api/sha256")]
    public class Sha256Controller : BaseController
    {
        public Sha256Controller(ILoggerFactory loggerFactory)
            : base(loggerFactory.CreateLogger(nameof(EnvironmentController)))
        {
        }

        [HttpGet()]
        public string Index(string input)
        {
            if (input == null) { return "no input"; }

            var toHash = input;
            var toHashBytes = System.Text.Encoding.UTF8.GetBytes(toHash);

            SHA256 sha = SHA256.Create();
            var hashSum = sha.ComputeHash(toHashBytes);

            return BitConverter.ToString(hashSum).Replace("-", string.Empty);
        }
    }
}
