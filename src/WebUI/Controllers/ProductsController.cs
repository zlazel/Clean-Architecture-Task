using Canteen.Application.Products.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clean_Architecture_Task.WebUI.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCommand { Id = id });

            return NoContent();
        }
    }
}
