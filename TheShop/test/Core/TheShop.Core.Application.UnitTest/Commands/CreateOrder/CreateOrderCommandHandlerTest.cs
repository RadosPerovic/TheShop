using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace TheShop.Core.Application.UnitTest.Commands.CreateOrder
{
    public class CreateOrderCommandHandlerTest
    {
        private Fixture _fixture;

        public CreateOrderCommandHandlerTest()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public async Task CreateOrderCommand_Valid()
        {
            //Arrange

            var handler = _fixture.GetCreateOrderHandler();
            var command = CreateOrderCommandHelper.GetValidCreateOrderCommand();

            //Act

            var result = await handler.Handle(command, System.Threading.CancellationToken.None);

            //Assert

            result.IsSuccessful.Should().BeTrue();
            result.Message.Should().BeNull();
        }

        [Fact]
        public async Task CreateOrderCommand_Invalid_NonExistingArticle()
        {
            //Arrange

            var handler = _fixture.GetCreateOrderHandler();
            var command = CreateOrderCommandHelper.GetNonExistingArticleCreateOrderCommand();

            //Act

            var result = await handler.Handle(command, System.Threading.CancellationToken.None);

            //Assert

            result.IsSuccessful.Should().BeFalse();
            result.Message.Should().NotBeEmpty();
        }

        [Fact]
        public async Task CreateOrderCommand_Invalid_NonExistingCustomer()
        {
            //Arrange

            var handler = _fixture.GetCreateOrderHandler();
            var command = CreateOrderCommandHelper.GetNonExistingCustomerCreateOrderCommand();

            //Act

            var result = await handler.Handle(command, System.Threading.CancellationToken.None);

            //Assert

            result.IsSuccessful.Should().BeFalse();
            result.Message.Should().NotBeEmpty();
        }

        [Fact]
        public async Task CreateOrderCommand_Invalid_BadQuantity()
        {
            //Arrange

            var handler = _fixture.GetCreateOrderHandler();
            var command = CreateOrderCommandHelper.GetBadQuantityCreatedOrderCommand();

            //Act

            var result = await handler.Handle(command, System.Threading.CancellationToken.None);

            //Assert

            result.IsSuccessful.Should().BeFalse();
            result.Message.Should().NotBeEmpty();
        }

        [Fact]
        public async Task CreateOrderCommand_Invalid_InappropriateMaxExpectedPrice()
        {
            //Arrange

            var handler = _fixture.GetCreateOrderHandler();
            var command = CreateOrderCommandHelper.GetInappropriateMaxExpectedPrice();

            //Act

            var result = await handler.Handle(command, System.Threading.CancellationToken.None);

            //Assert

            result.IsSuccessful.Should().BeFalse();
            result.Message.Should().NotBeEmpty();
        }
    }
}
