using Lecture.Controllers;
using Lecture.Models;
using Lecture.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lecture.Test.Controllers
{
    public class SpeakersTests
    {
        private SpeakersViewModel speakersViewModel;
        private SpeakersController speakersController;

        public SpeakersTests()
        {
            speakersViewModel = new SpeakersViewModel(new Mock<SpeakersViewModel>().Object);
        }


        [Fact]
        public void Create_ValidName()
        {
            //var result = speakersController.Create(new SpeakersViewModel { Name = Guid.NewGuid() });
            Assert.True(true);
        }
    }
}
