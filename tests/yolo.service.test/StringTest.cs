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
	}
}

