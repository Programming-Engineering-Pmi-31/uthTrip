namespace uthTrip.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Review_ID { get; set; }

        public int Writer_ID { get; set; }

        public int Trip_ID { get; set; }

        [Column("Review")]
        [StringLength(150)]
        public string Review1 { get; set; }

        public int? Mark { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual User User { get; set; }
    }
}
