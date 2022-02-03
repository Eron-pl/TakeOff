using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeOff.Resources;
using Xunit;

namespace TakeOff.Tests
{
    public class DownloaderTests
    {
        [Fact]
        public void ShouldFileDownloadedExists()
        {
            //Arrange 
            var request = new Program()
            {
                DownloadLink = "https://dl.discordapp.net/distro/app/stable/win/x86/1.0.9003/DiscordSetup.exe"
            };

            //Act
            var result = Downloader.Download(request.DownloadLink, @"C:\TakeOff Downloads\");

            //Assert
            Assert.True(result);
        }
    }
}
