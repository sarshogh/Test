using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Sample.RequestsResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Sample.Controllers
{

    [DisableCors][AllowAnonymous][Route("api/v1/[controller]/")]
    [ApiController][IgnoreAntiforgeryToken]
    public class ValuesController : ControllerBase
    {
        IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
        [HttpPost("get-my-info")]
        public async Task<IActionResult> SampleGet(GetMyInfoRequest request)
        {
            var result =await _mediator.Send(request);
            return Ok(result);
        }        
    }
}
