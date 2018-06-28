using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("UnitTests")]
namespace XUnitAndFluentAssertionDemo
{
    internal class Hello
    {
        private string _firstName { get; set; }
        private string _lastName { get; set; }

        public Hello(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string HelloMan()
        {
            if (string.IsNullOrEmpty(_firstName))
                throw new MissingFirstNameException();

            return this.HelloMan(_firstName, _lastName);
        }

        private string HelloMan(string firstName, string lastName)
        {
            return $"Hello {firstName} {lastName} !";
        }
    }

    public class MissingFirstNameException: Exception
    {
        public MissingFirstNameException(): base("FirstName is missing")
        {
        }
    }
}