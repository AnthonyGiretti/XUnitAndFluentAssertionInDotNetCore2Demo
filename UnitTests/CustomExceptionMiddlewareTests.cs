using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
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
            // Arrange
            var middleware = new CustomExceptionMiddleware((innerHttpContext) =>
            {
                throw new NotFoundCustomException("Test", "Test");
            });

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //Act
            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var streamText = reader.ReadToEnd();
            var objResponse = JsonConvert.DeserializeObject<CustomErrorResponse>(streamText);

            //Assert
            objResponse
            .Should()
            .BeEquivalentTo(new CustomErrorResponse { Message = "Test", Description = "Test" });

            context.Response.StatusCode
                .Should()
                .Be((int)HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task WhenAnUnExpectedExceptionIsRaised_CustomExceptionMiddlewareShouldHandleItToCustomErrorResponseAndInternalServerErrorHttpStatus()
        {
            // Arrange
            var middleware = new CustomExceptionMiddleware(next: (innerHttpContext) =>
            {
                throw new Exception("Test");
            });

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            //Act
            await middleware.Invoke(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(context.Response.Body);
            var streamText = reader.ReadToEnd();
            var objResponse = JsonConvert.DeserializeObject<CustomErrorResponse>(streamText);

            //Assert
            objResponse
            .Should()
            .BeEquivalentTo(new CustomErrorResponse { Message = "Unexpected error", Description = "Unexpected error" });

            context.Response.StatusCode
                .Should()
                .Be((int)HttpStatusCode.InternalServerError);

        }
    }
}
