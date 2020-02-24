using Canteen.Application.Categories.Commands;
using Clean_Architecture_Task.Application.Common.Exceptions;
using Clean_Architecture_Task.Application.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Clean_Architecture_Task.Application.UnitTests.Categories.Commands.UpdateTodoItem
{
    public class UpdateCategoryCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedTodoItem()
        {
            var command = new UpdateCommand
            {
                Id = 1,
                Name = "Category 1",
                Disabled = false
            };

            var handler = new UpdateCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.Categories.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.Name.ShouldBe(command.Name);
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateCommand
            {
                Id = 99,
              Name = "asdas",
              Disabled = false
            };

            var sut = new UpdateCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() => 
                sut.Handle(command, CancellationToken.None));
        }
    }
}