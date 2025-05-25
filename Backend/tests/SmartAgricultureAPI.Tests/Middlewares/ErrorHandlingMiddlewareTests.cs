using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Exceptions;
using Xunit;

namespace SmartAgricultureAPI.Middlewares.Tests;

public class ErrorHandlingMiddlewareTests
{
    [Fact()]
    public async Task InvokeAsync_WhenNoExceptionThrown_ShouldCallNextDelegate()
    {

        // arange
        var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
        var middleware = new ErrorHandlingMiddleware(loggerMock.Object);
        var context = new DefaultHttpContext();
        var nextDelegateMock = new Mock<RequestDelegate>();


        // act
        await middleware.InvokeAsync(context,nextDelegateMock.Object);


        // assert
        nextDelegateMock.Verify(next => next.Invoke(context), Times.Once);
    }

    [Fact()]
    public async Task InvokeAsync_WhenNotFoundExceptionThrown_ShouldSetStatusCode404()
    {

        // arange
        var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
        var middleware = new ErrorHandlingMiddleware(loggerMock.Object);
        var context = new DefaultHttpContext();
        var notFoundException = new NotFoundException(nameof(Farm), "1"); 


        // act
        await middleware.InvokeAsync(context, _ => throw notFoundException);


        // assert
        context.Response.StatusCode.Should().Be(404);
    } 
    
    [Fact()]
    public async Task InvokeAsync_WhenGenericExceptionThrown_ShouldSetStatusCode500()
    {

        // arange
        var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
        var middleware = new ErrorHandlingMiddleware(loggerMock.Object);
        var context = new DefaultHttpContext();
        var genericException = new Exception();
        

        // act
        await middleware.InvokeAsync(context, _ => throw genericException);


        // assert
        context.Response.StatusCode.Should().Be(500);
    }
}