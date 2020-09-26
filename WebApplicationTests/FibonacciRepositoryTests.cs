using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Application.AddNumbers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;


namespace WebApplicationTests
{
    [TestFixture]
    public class FibonacciRepositoryTests
    {

        private ServiceProvider serviceProvider { get; set; }
        
        [SetUp]
        public void Setup()
        {
          
        }

        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(-1, 1, 0)]
        public async Task GetValueFromFibonaciSequence_WhenCalled_ReturnValue(int value1, int value2, long acceptedValue)
        {
            var addNumbersRepository = new AddNumbersRepository();

            var result = await addNumbersRepository.GetAddNumbersSum(value1, value2);

            Assert.That(result.Result, Is.EqualTo(acceptedValue));

        }
    }
}