using Canteen.Application.Products.Commands;
using Canteen.Application.Products.Models;
using Canteen.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean_Architecture_Task.WebUI.Controllers
{
    public class ProductsController : ApiController
    {
          [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            return await Mediator.Send(new GetById {Id = id });
        }
         [HttpGet]
        public async Task<ActionResult<List<ProductLiDto>>> GetAll()
        {
            return await Mediator.Send(new GetAll());
        }
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
