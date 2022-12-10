using System;
using yolo.service.implementations;

namespace yolo.service.test
{
	[TestClass]
	public class StringTest
	{
		public StringTest()
		{
		}

		[TestMethod]
		public void Reverse_Success()
		{
			//Arrange
			string item = "test";
			var stringService = new StringService();
			//Act
			var result = stringService.Reverse(item);
            //Assert
            Assert.IsTrue(result == "tset");
		}

		[TestMethod]
		public void Reverse_Empty()
		{
            //Arrange
            string item = string.Empty;
            var stringService = new StringService();
            //Act
            var result = stringService.Reverse(item);
            //Assert
            Assert.IsTrue(result == string.Empty);
        }

        [TestMethod]
        public void Reverse_Null()
        {
            //Arrange
            string item = null;
            var stringService = new StringService();
            //Act
            var result = stringService.Reverse(item);
            //Assert
            Assert.IsTrue(result == string.Empty);
        }
    }
}

