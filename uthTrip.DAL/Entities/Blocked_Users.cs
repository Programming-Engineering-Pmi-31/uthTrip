namespace uthTrip.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Blocked_Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Blocked_ID { get; set; }

        public int? User_ID { get; set; }

        public virtual User User { get; set; }
    }
}
