namespace uthTrip.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Right
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rights_ID { get; set; }
        
        public int User_ID { get; set; }

        public int Role_ID { get; set; }

        public int Trip_ID { get; set; }

        public virtual Role Role { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual User User { get; set; }
    }
}
