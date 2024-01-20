using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Lectures.Interface;
using Lectures.Services;
using Lecture.ViewModels;

namespace Lecture.Test
{
    public class SpeakersServiceTests
    {
        [Fact]
        public async Task CreateSpeakerAsync_ValidModel_ReturnsTrue()
        {
            // Arrange
            var dbContextMock = new Mock<IAppDbContext>();
            var speakersService = new SpeakersService((Models.AppDbContext)dbContextMock.Object);
            var validModel = new SpeakersViewModel(); // Preencher com dados válidos conforme necessário

            // Act
            var result = await speakersService.CreateSpeakerAsync(validModel);

            // Assert
            Assert.True(result);
        }

        // Adicione mais testes conforme necessário
    }

}
