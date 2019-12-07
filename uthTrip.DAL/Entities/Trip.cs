namespace UthTrip.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Reviewed.")]
        public Trip()
        {
            this.Reviews = new HashSet<Review>();
            this.Rights = new HashSet<Right>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Trip_ID { get; set; }

       
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Title of trip shold have from 10 to 100 symbols")]
        [Required]
        public string Trip_Title { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Write some information about your trip")]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }

        public int Date_ID { get; set; }
        [Required]
        public int Number_Of_People { get; set; }

        public int Destination_ID { get; set; }

        public int Creator_ID { get; set; }

        public virtual Dates_ranges Dates_ranges { get; set; }

        public virtual Destination Destination { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Reviewed.")]
        public virtual ICollection<Review> Reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Reviewed.")]
        public virtual ICollection<Right> Rights { get; set; }

        public virtual User User { get; set; }
    }
}
