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
        //[Route("/values")]
        //[HttpGet]
        //public string GetAll()
        //{
        //    return "value";
        //}
        //[Route("/values")]
        [HttpGet]
        public List<ApplicationUser> GetAll()
        {
            var listing = new List<ApplicationUser>();
            var list = _context.Users;
            listing.AddRange(list);
            return listing;
        }

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

            return elist;
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
    //    public IActionResult GetMatch(int id)
    //    {
    //        Matches match = _context.Matches.Find(id);

    //        DataAroundMatch data = new DataAroundMatch();

    //        data.Match_FightTime = match.FightTime;
    //        data.Match_IsReport = match.IsReport;

    //        List<MatchUser> matchUserList = db.MatchUser.Where(x => x.IdMatch == match.Id).ToList();

    //        data.Users = new List<Person>();
    //        foreach (var item in matchUserList)
    //        {
    //            data.Users.Add(db.Person.FirstOrDefault(x => x.Id == item.Id));
    //        }

    //        Person reporUser = new Person();
    //        if (match.IsReport)
    //        {
    //            reporUser = db.Person.FirstOrDefault(x => x.Id == match.IdReport);
    //            data.Match_ReportUserFirstName = reporUser.FirstName;
    //            data.Match_ReportUserName = reporUser.Name;
    //        }

    //        Game game = new Game();
    //        game = db.Game.FirstOrDefault(x => x.Id == match.idGame);
    //        data.Match_GameDescription = game.Description;
    //        data.Match_GameName = game.Name;
    //        data.Match_GameSpecialRule = game.SpecialeRule;
    //        data.Match_GameUrl = game.URL;

    //        Tournament tournament = db.Tournament.FirstOrDefault(x => x.Id == match.IdTournament);
    //        data.Match_TournamentEndDate = tournament.DateFinish;
    //        data.Match_TournamentStartDate = tournament.DateStart;
    //        data.Match_TournamentIsDone = tournament.IsDone;

    //        Person winner = db.Person.FirstOrDefault(x => x.Id == match.IdWinner);
    //        if (winner != null)
    //        {
    //            data.Match_TournamentWinnerFirstName = winner.FirstName;
    //            data.Match_TournamentWinnerName = winner.Name;
    //        }

    //        Enterprise enterprise = db.Enterprise.FirstOrDefault(x => x.Id == tournament.IdEnterprise);
    //        data.Match_EnterpriseEndSchedule = enterprise.FinishSchedule;
    //        data.Match_EnterpriseStartSchedule = enterprise.StartSchedule;

    //        if (match == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(data);
    //    }
    }
}