using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAPI.DataAccess;
using WebApplicationAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationAPI.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {

        private readonly UserDetailsRepository _UserDetailsRepository;

        public UserDetailsController(UserDetailsRepository userDetailsRepository)
        {
            _UserDetailsRepository = userDetailsRepository;
        }

        // GET: api/<UserDetailsController>
        [HttpGet]
        public async Task<List<UserDetails>> Get()
        {
            return await _UserDetailsRepository.GetAllUserDetails();
        }

        // GET api/<UserDetailsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetails>> Get(int id)
        {
            var response = await _UserDetailsRepository.GetUserDetailById(id);
            if(response == null)
            {
                return NotFound();
            }
            return response;
        }

        // POST api/<UserDetailsController>
        [HttpPost]
        public async Task Post([FromBody] UserDetails userDetails)
        {
            await _UserDetailsRepository.InsertUserDetail(userDetails);
        }

        // PUT api/<UserDetailsController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] UserDetails userDetails, int id )
        {           
            await _UserDetailsRepository.UpdateUserDetail(userDetails, id);
        }

        // DELETE api/<UserDetailsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _UserDetailsRepository.DeleteUserDetail(id);
        }
    }
}
