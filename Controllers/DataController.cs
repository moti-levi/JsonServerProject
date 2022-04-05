using JsonServerProject.Api;
using JsonServerProject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JsonServerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        // GET: api/<ValuesController>
        //// GET: api/<DataControllerModel>
        [AllowAnonymous]
        [HttpGet("{from}/{itemsPerPage}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DataControllerModel>>> Get(int from, int itemsPerPage)
        {
            RequestApi contentApi = new RequestApi();
            var response = await contentApi.GetContent(from, itemsPerPage);
            return Ok(response);
        }

        //// GET: api/<DataControllerModel>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DataControllerModel>>> Get()
        {
            RequestApi contentApi = new RequestApi();
            var response = await contentApi.GetContent();
            return Ok(response);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
