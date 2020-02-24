using Canteen.Application.Products.Commands;
using Clean_Architecture_Task.Application.Common.Exceptions;
using Clean_Architecture_Task.Application.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Clean_Architecture_Task.Application.UnitTests.Products.Commands.UpdateTodoItem
{
    public class UpdateProductCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedTodoItem()
        {
            var command = new UpdateCommand
            {
                Id = 1 ,
                Name  = "TShirt",
                SellingPrice = 70,
                Description = "Description ..",
                CategoryId = 1,
                Disabled = true
            };

            var handler = new UpdateCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.TodoItems.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.Title.ShouldBe(command.Name);
            entity.Done.ShouldBeTrue();
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateCommand
            {
                 Id = 123,
                Name  = "TShirt",
                SellingPrice = 70,
                Description = "Description ..",
                CategoryId = 1,
                Disabled = true
            };

            var sut = new UpdateCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() => 
                sut.Handle(command, CancellationToken.None));
        }
    }
}