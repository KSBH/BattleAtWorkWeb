namespace BattleAtWork_WebApi.Model_EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("Match")]
    public partial class Match
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Match()
        {
            MatchUser = new HashSet<MatchUser>();
        }

        public string Id { get; set; }

        public int? IdTournament { get; set; }

        public Guid? IdWinner { get; set; }

        public DateTime? FightTime { get; set; }

        public Guid? IdReport { get; set; }

        public bool IsReport { get; set; }

        public Guid? idGame { get; set; }

        public virtual Game Game { get; set; }

        public virtual Tournament Tournament { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchUser> MatchUser { get; set; }
    }
}
