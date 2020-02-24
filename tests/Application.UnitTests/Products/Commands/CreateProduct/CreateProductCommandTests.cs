using Canteen.Application.Products.Commands;
using Clean_Architecture_Task.Application.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Clean_Architecture_Task.Application.UnitTests.Products.Commands.CreateProduct
{
    public class CreateProductCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistTodoItem()
        {
            var command = new CreateCommand
            {
                Name  = "TShirt",
                SellingPrice = 90,
                Description = "Description ..",
                BarCode = "ABC_000001",
                CategoryId = 1,
                Disabled = false
            };
            var handler = new CreateCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Products.Find(result);

            entity.ShouldNotBeNull();
            entity.Name.ShouldBe(command.Name);
        }
    }
}
