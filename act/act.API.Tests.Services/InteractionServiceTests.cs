using act.API.Tests.Controllers;
using act.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace act.API.Tests.Services
{
    [TestClass]
    public class InteractionServiceTests : TestBase
    {
        //NOTE: should be replaced by an interface
        IInteractionService _service;

        public InteractionServiceTests() : base()
        {
            _service = _serviceProvider.GetRequiredService<IInteractionService>();
        }

        [TestMethod]
        public async Task Service_Works()
        {
            var result = await _service.Test();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CreateRelation()
        {
            var result = await  _service.CreateInteraction("Test");
            Assert.Equals(result.Id, 1);

        }
    }
}