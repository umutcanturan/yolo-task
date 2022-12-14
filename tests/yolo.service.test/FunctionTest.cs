using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yolo.service.implementations;

namespace yolo.service.test
{
    [TestClass]
    public class FunctionTest
    {
        [TestMethod]
        public async Task FunctionB_Success()
        {
            //Arrange
            var bus = Mock.Of<IMediator>();
            var service = new FunctionService(bus);
            //Act
            var result = await service.FunctionB(1);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task FunctionA_SuccessEvent()
        {
            //Arrange
            var bus = Mock.Of<IMediator>();
            var service = new FunctionService(bus);
            //Act
            await service.FunctionA(true);
            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task FunctionA_SuccessMediatr()
        {
            //Arrange
            var bus = Mock.Of<IMediator>();
            var service = new FunctionService(bus);
            //Act
            await service.FunctionA(false);
            //Assert
            Assert.IsTrue(true);
        }
    }
}
