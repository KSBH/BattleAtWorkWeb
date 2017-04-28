using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BattleAtWork.Data;
using BattleAtWork.Models;
using Microsoft.AspNetCore.Identity;

namespace BattleAtWork.Controllers
{
    [Produces("application/json")]
    [Route("api/API")]
    public class APIController : Controller
    {
        public ApplicationDbContext _context;
        public UserManager<ApplicationUser> _usermanager;
        public APIController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }
        // GET api/values
        [Route("/values")]
        [HttpGet]
        public string GetAll()
        {
            return "value";
        }
        //[Route("/values")]
        //[HttpGet]
        //public List<ApplicationUser> GetAll()
        //{
        //    var listing = new List<ApplicationUser>();
        //    var list = _context.Users;
        //    listing.AddRange(list);
        //    return listing;
        //}

        // GET api/values/5
        [Route("/{id}")]
        [HttpGet("{id}")]
        public async Task<ApplicationUser> Get(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);
            return user;
        }
        [Route("/Post")]
        // POST api/values
        [HttpPost]
        public List<ApplicationUser> Post([FromBody]List<ApplicationUser> elist)
        {
            return null;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}