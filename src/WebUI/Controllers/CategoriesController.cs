using Canteen.Application.Categories.Commands;
using Canteen.Application.Categories.Models;
using Canteen.Application.Categories.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean_Architecture_Task.WebUI.Controllers
{
    public class CategoriesController : ApiController
    {
         [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            return await Mediator.Send(new GetById {Id = id });
        }
         [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            return await Mediator.Send(new GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCommand command)
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
