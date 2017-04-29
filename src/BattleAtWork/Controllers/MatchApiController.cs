using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BattleAtWork.Models;
using BattleAtWork.Data;
using BattleAtWork_WebApi.Model_EF;

namespace BattleAtWork.Controllers
{
    [Produces("application/json")]
    [Route("api/MatchApi")]
    public class MatchApiController : Controller
    {
        public ApplicationDbContext _context;

        public MatchApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult GetMatch(string id)
        {
            Match match = _context.Match.FirstOrDefault(x=>x.Id == id);

            DataAroundMatch data = new DataAroundMatch();

            data.Match_FightTime = match.FightTime;
            data.Match_IsReport = match.IsReport;

            List<MatchUser> matchUserList = _context.MatchUser.Where(x => x.IdMatch == match.Id).ToList();

            data.Users = new List<ApplicationUser>();
            foreach (var item in matchUserList)
            {
                data.Users.Add(_context.Users.FirstOrDefault(x => x.Id == item.Id));
            }

            var reporUser = new ApplicationUser();
            if (match.IsReport)
            {
                reporUser = _context.Users.FirstOrDefault(x => x.Id == match.IdReport.ToString());
                data.Match_ReportUserFirstName = reporUser.FristName;
                data.Match_ReportUserName = reporUser.LastName;
            }

            Game game = new Game();
            game = _context.Game.FirstOrDefault(x => x.Id == match.idGame.ToString());
            data.Match_GameDescription = game.Description;
            data.Match_GameName = game.Name;
            data.Match_GameSpecialRule = game.SpecialeRule;
            data.Match_GameUrl = game.URL;

            Tournament tournament = _context.Tournament.FirstOrDefault(x => x.Id == match.IdTournament);
            data.Match_TournamentEndDate = tournament.DateFinish;
            data.Match_TournamentStartDate = tournament.DateStart;
            data.Match_TournamentIsDone = tournament.IsDone;

            var winner = _context.Users.FirstOrDefault(x => x.Id == match.IdWinner.ToString());
            if (winner != null)
            {
                data.Match_TournamentWinnerFirstName = winner.FristName;
                data.Match_TournamentWinnerName = winner.LastName;
            }

            Enterprise enterprise = _context.Enterprise.FirstOrDefault(x => x.Id == tournament.IdEnterprise.ToString());
            data.Match_EnterpriseEndSchedule = enterprise.FinishSchedule;
            data.Match_EnterpriseStartSchedule = enterprise.StartSchedule;

            if (match == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}