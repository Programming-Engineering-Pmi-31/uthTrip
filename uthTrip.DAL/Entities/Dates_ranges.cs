namespace UthTrip.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dates_ranges
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Reviewed.")]
        public Dates_ranges()
        {
            this.Trips = new HashSet<Trip>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Date_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Reviewed.")]
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
