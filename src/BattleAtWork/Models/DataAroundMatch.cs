using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleAtWork.Models
{
    public class DataAroundMatch
    {
        public DateTime? Match_FightTime { get; set; }
        public bool Match_IsReport { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public string Match_ReportUserName { get; set; }
        public string Match_ReportUserFirstName { get; set; }

        public string Match_GameName { get; set; }
        public string Match_GameDescription { get; set; }
        public string Match_GameSpecialRule { get; set; }
        public string Match_GameUrl { get; set; }

        public DateTime? Match_TournamentStartDate { get; set; }
        public DateTime? Match_TournamentEndDate { get; set; }
        public bool? Match_TournamentIsDone { get; set; }
        public string Match_TournamentWinnerName { get; set; }
        public string Match_TournamentWinnerFirstName { get; set; }

        public DateTime? Match_EnterpriseStartSchedule { get; set; }
        public DateTime? Match_EnterpriseEndSchedule { get; set; }
    }
}
