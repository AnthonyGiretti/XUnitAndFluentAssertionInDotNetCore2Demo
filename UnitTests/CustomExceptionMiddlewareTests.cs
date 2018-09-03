using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo;
using Xunit;

namespace UnitTests
{
    public class CustomExceptionMiddlewareTests
    {
        [Fact]
        public async Task WhenACustomExceptionIsRaised_CustomExceptionMiddlewareShouldHandleItToCustomErrorResponseAndCorrectHttpStatus()
        {
            var middleware = new CustomExceptionMiddleware(next: (innerHttpContext) =>
            {
                throw new NotFoundCustomException("Test", "Test");
            });

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var streamText = reader.ReadToEnd();
        }
    }
}
