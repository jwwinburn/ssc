using Microsoft.AspNetCore.Mvc;
using System;
using ServerSideApiAttempt1.Models;
using ServerSideApiAttempt1.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSideApiAttempt1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        // GET: api/<UsersController>
        [HttpGet("getByFirebaseUserId/{firebaseUserid}")]
        public IActionResult GetByFirebaseUserId(string firebaseUserid)
            
        {
            return Ok(_usersRepository.GetByFirebaseUserId(firebaseUserid));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
