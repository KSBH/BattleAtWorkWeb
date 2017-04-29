namespace BattleAtWork_WebApi.Model_EF
{
    using BattleAtWork.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("MatchUser")]
    public partial class MatchUser
    {
        public string Id { get; set; }

        public string IdMatch { get; set; }

        public string IdUser { get; set; }

        public virtual Match Match { get; set; }

        public virtual ApplicationUser Person { get; set; }
    }
}
