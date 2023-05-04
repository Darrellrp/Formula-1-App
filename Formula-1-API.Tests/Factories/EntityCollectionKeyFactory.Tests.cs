using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Formula_1_API.Factories;
using Xunit;

namespace Formula_1_API.Tests.Factories
{
    public class EntityCollectionKeyFactoryTests
    {
        private EntityCollectionLabelFactory _sut = new EntityCollectionLabelFactory();

        [Fact]
        public void CreateAllKeys()
        {
            // Arrange

            // Act
            var keys = _sut.CreateAllLabels();

            // Assert
            keys.Should().NotBeNull();
        }

        [Fact]
        public void CreateSingleKey()
        {
            // Arrange

            // Act
            var keys = _sut.CreateSingleLabel<Models.Race>();

            // Assert
            keys.Should().NotBeNull();
        }
    }
}