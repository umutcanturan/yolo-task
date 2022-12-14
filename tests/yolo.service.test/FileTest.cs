using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using yolo.service.implementations;

namespace yolo.service.test
{
    [TestClass]
    public class FileTest
    {
        [TestMethod]
        public void Download_Fail()
        {
            //Arrange
            var expectedExcetpion = new Exception("File download failed");
            var fileService = new FileService();
            // Act & Assert
            var result = Assert.ThrowsException<Exception>(() => fileService.ComputeSHA("test"));
            Assert.AreEqual(expectedExcetpion.Message, result.Message);
        }
    }
}
