namespace UthTrip.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trip()
        {
            Reviews = new HashSet<Review>();
            Rights = new HashSet<Right>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Trip_ID { get; set; }

        [StringLength(100)]
        public string Trip_Title { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public double Price { get; set; }

        public int Date_ID { get; set; }

        public int Number_Of_People { get; set; }

        public int Destination_ID { get; set; }

        public int Creator_ID { get; set; }

        public virtual Dates_ranges Dates_ranges { get; set; }

        public virtual Destination Destination { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Right> Rights { get; set; }

        public virtual User User { get; set; }
    }
}
