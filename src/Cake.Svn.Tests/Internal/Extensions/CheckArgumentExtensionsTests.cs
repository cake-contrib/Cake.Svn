using System;
using Cake.Svn.Internal.Extensions;
using Xunit;

namespace Cake.Svn.Tests.Internal.Extensions
{
    public sealed class CheckArgumentExtensionsTests
    {
        public sealed class CheckIfNull
        {
            [Fact]
            public void Should_Throw_ArgumentNullException_If_Object_Is_Null()
            {
                // Given
                object nullObject = null;
                
                // Then
                Assert.Throws<ArgumentNullException>("this", () => nullObject.NotNull("this"));
            }

            [Fact]
            public void Should_Pass_If_Object_Is_Set()
            {
                // Given
                object objectToCheck = this;

                // When
                objectToCheck.NotNull("nullObject");
            }
        }

        public sealed class CheckIfNullOrWhitespace
        {
            [Fact]
            public void Should_Throw_ArgumentNullException_If_String_Is_Null()
            {
                // Given
                string nullString = null;

                // Then
                Assert.Throws<ArgumentNullException>("this", () => nullString.NotNullOrWhiteSpace("this"));
            }

            [Fact]
            public void Should_Throw_ArgumentNullException_If_String_Is_Empty()
            {
                // Given
                string emptyString = string.Empty;

                // Then
                Assert.Throws<ArgumentOutOfRangeException>("emptyString", () => emptyString.NotNullOrWhiteSpace("emptyString"));
            }

            [Fact]
            public void Should_Throw_ArgumentNullException_If_String_HasOnly_Whitespaces()
            {
                // Given
                string whitespaceString = "    ";

                // Then
                Assert.Throws<ArgumentOutOfRangeException>("whitespaceString", () => whitespaceString.NotNullOrWhiteSpace("whitespaceString"));
            }

            [Fact]
            public void Should_Pass_If_String_And_ParameterName_Are_Set()
            {
                // Given
                string stringToCheck = "myString";

                // When
                stringToCheck.NotNullOrWhiteSpace("stringToCheck");
            }
        }
    }
}
