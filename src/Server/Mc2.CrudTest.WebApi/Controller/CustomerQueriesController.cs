using Mc2.CrudTest.Queries.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mc2.CrudTest.WebApi.Controller
{
    [Route("api/customers")]
    [ApiController]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class CustomerQueriesController : ControllerBase
    {
        private readonly IGetCustomerListQuery getListQuery;
        private readonly IGetCustomerQuery getQuery;

        public CustomerQueriesController(
            IGetCustomerListQuery getListQuery,
            IGetCustomerQuery getQuery)
        {
            this.getListQuery = getListQuery;
            this.getQuery = getQuery;
        }



        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            var result = getListQuery.Execute();
            return Ok(result);
        }

        [Route("by/{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = getQuery.Execute(id);
            return Ok(result);
        }
    }
}
