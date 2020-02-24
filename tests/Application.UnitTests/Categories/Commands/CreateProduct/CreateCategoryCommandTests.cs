using Canteen.Application.Categories.Commands;
using Clean_Architecture_Task.Application.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Clean_Architecture_Task.Application.UnitTests.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistCategory()
        {
            var command = new CreateCommand
            {
                Name  = "General Clothes",
                Disabled = false
            };
            var handler = new CreateCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Categories.Find(result);

            entity.ShouldNotBeNull();
            entity.Name.ShouldBe(command.Name);
        }
    }
}
