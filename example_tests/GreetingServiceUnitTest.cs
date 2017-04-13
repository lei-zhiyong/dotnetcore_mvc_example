using Xunit;
using Moq;
using datas;
using services;
using Microsoft.Extensions.Configuration;

namespace example_tests
{
    public class GreetingServiceUnitTest
    {
        [Fact]
        public void TestGreetingService()
        {
            //moq相关依赖，并且执行service方法得到结果
            var config = new Mock<IConfigurationRoot>();

            var repository = new Mock<Repository>(config.Object);
            repository.Setup(p=>p.GetGreeting(1)).Returns(MoqGreetingData());

            var service = new GreetingService(repository.Object);
            var result =  service.GetGreetings("world"); 

            Assert.NotNull(result);
            
            Assert.Equal(result.Greetings, "hello world!");
        }

        private Greeting MoqGreetingData()
        {
            return new Greeting() { Greetings = $"hello" };
        }
    }
}
