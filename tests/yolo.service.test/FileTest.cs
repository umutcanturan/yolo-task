using config = Microsoft.Extensions.Configuration;
using Moq;
using yolo.common.exceptions;
using yolo.service.implementations;
using Microsoft.Extensions.Configuration;

namespace yolo.service.test
{
    [TestClass]
    public class FileTest
    {
        private readonly config.IConfiguration Configuration;
        public FileTest() {
            var customConfig = new Dictionary<string, string>
            {
                {"DownloadDirectory", "..//files//"},
                {"DefaultFileUrl", "https://speed.hetzner.de/100MB.bin"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(customConfig)
                .Build();
            Configuration = configuration;
        }

        [TestMethod]
        public void Download_Fail()
        {
            //Arrange
            var exceptionMessage = "File download failed";

            var fileService = new FileService(Configuration);
            // Act
            Exception retEx = null;

            try
            {
                fileService.ComputeSHA("test");
            }
            catch (Exception ex)
            {
                retEx = ex;
            }
            // Assert
            Assert.IsTrue(retEx.Message.StartsWith(exceptionMessage));
        }

        [TestMethod]
        public void Download_Success()
        {
            //Arrange
            var fileService = new FileService(Configuration);
            //Act
            var result = fileService.ComputeSHA();
            //Assert
            Assert.AreEqual(result, "Completed");
        }
    }
}
