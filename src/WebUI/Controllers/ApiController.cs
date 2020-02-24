using AutoMapper;
using Clean_Architecture_Task.Application.Common.Exceptions;
using Clean_Architecture_Task.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Clean_Architecture_Task.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public async Task<ActionResult> MobileExecute<TRequest>(IRequest<TRequest> request, string Msg)
        {
            try
            {
                var response = await Mediator.Send(request);
                return Ok(new ApiResponse<TRequest> { Data = response, Message = Msg, StatusCode = (int)HttpStatusCode.OK });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<object> { Message = ex.Message, StatusCode = (int)HttpStatusCode.NotFound });
            }
            catch (AddEntityFailureException ex)
            {
                return Conflict(new ApiResponse<object> { Message = ex.Message, StatusCode = (int)HttpStatusCode.NotFound });
            }
            catch (DeleteFailureException ex)
            {
                return BadRequest(new ApiResponse<object> { Message = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest });
            }
            catch (NameIsAlreadyExistsException ex)
            {
                return Conflict(new ApiResponse<object> { Message = ex.Message, StatusCode = (int)HttpStatusCode.Conflict });
            }
            catch (AutoMapperMappingException ex)
            {
                return Conflict(new ApiResponse<object> { Message = ex.Message, StatusCode = (int)HttpStatusCode.Conflict });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new ApiResponse<IDictionary<string, string[]>> { Data = ex.Failures, Message = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object> { Message = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest });
            }
        }
    }
}
