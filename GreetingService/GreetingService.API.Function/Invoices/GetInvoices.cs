using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using GreetingService.API.Function.Authentication;
using GreetingService.Core.Entities;
using GreetingService.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GreetingService.API.Function
{
    public class GetInvoices
    {
        private readonly ILogger<GetInvoices> _logger;
        private readonly IAuthHandler _authHandler;
        private readonly IInvoiceService _invoiceService;

        public GetInvoices(ILogger<GetInvoices> log, IAuthHandler authHandler, IInvoiceService invoiceService)
        {
            _logger = log;
            _authHandler = authHandler;
            _invoiceService = invoiceService;
        }

        [FunctionName("GetInvoices")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "Invoice" })]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.Accepted, Description = "Accepted")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "invoice/{year}/{month}")] HttpRequest req, int year, int month)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            if (!await _authHandler.IsAuthorizedAsync(req))
                return new UnauthorizedResult();

            var invoices = await _invoiceService.GetInvoicesAsync(year, month);
            return new OkObjectResult(invoices);
        }
    }
}

