using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;
using XUnitAndFluentAssertionDemo;

namespace UnitTests
{
    public class HelloTests
    {
        [Fact]
        public void PrivateHelloManShouldBeWellFormated()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";

            Type type = typeof(Hello);
            var hello = Activator.CreateInstance(type, firstName, lastName);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                                    .Where(x => x.Name == "HelloMan" && x.IsPrivate)
                                    .First();

            //Act
            var helloMan = (string)method.Invoke(hello, new object [] {firstName, lastName});


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
    }
}
