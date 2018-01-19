﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitAndFluentAssertionDemo;

namespace UnitTests
{
    public class HelloTests
    {
        [Fact]
        public void HelloManShouldBeWellFormated()
        {
            // Arrange
            var hello = new Hello("John", "Doe");

            //Act
            var helloMan = hello.HelloMan();


            //Assert
            helloMan
                .Should()
                .StartWith("Hello")
                .And
                .EndWith("!")
                .And
                .Contain("John")
                .And
                .Contain("Doe");

        }

        [Fact]
        public void HelloManShouldBeRaiseExceptionWhenFirstNameIsNotSet()
        {
            // Arrange
            var hello = new Hello("", "Doe");

            //Act
            Action actionHelloMan = () => hello.HelloMan();


            //Assert
            actionHelloMan
                .Should()
                .Throw<MissingFirstNameException>()
                .WithMessage("FirstName is missing");

        }
    }
}