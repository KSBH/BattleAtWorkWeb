using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleAtWork.Models
{
    public class Tournoi
    {
        public string Id { get; set; }
        public string Name { get;set;}
        public List<Matches> Matches { get; set; }
        public bool Done { get; set; }
        public DateTime Date { get; set; }
    }
}
