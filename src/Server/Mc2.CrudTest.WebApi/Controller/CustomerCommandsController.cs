using Mc2.CrudTest.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mc2.CrudTest.WebApi.Controller
{
    [Route("api/customers")]
    [ApiController]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class CustomerCommandsController : ControllerBase
    {
        private readonly IAddCustomerCommand addCommand;
        private readonly IDeleteCustomerCommand deleteCommand;
        private readonly IUpdateCustomerCommand updateCommand;

        public CustomerCommandsController(
            IAddCustomerCommand addCommand,
            IDeleteCustomerCommand deleteCommand,
            IUpdateCustomerCommand updateCommand)
        {
            this.addCommand = addCommand;
            this.deleteCommand = deleteCommand;
            this.updateCommand = updateCommand;
        }

 

        [HttpPost]
        [IgnoreAntiforgeryToken]
        //[ValidateModel]
        [Route("add")]
        public IActionResult Add([FromBody] CustomerDto dto)
        {
            addCommand.Execute(Guid.NewGuid(), dto);
            return Ok();
        }

        [Route("edit/{id}")]
        [HttpPatch]
        [IgnoreAntiforgeryToken]
        //[ValidateModel]
        public IActionResult Edit([FromRoute] Guid id, [FromBody] CustomerDto dto)
        {
            updateCommand.Execute(id, dto);
            return Ok();
        }


        [Route("delete/{id}")]
        [HttpDelete]
        [IgnoreAntiforgeryToken]
        public IActionResult Delete([FromRoute] Guid id)
        {
            deleteCommand.Execute(id);
            return Ok();
        }
    }
}
