namespace UthTrip.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        internal ICollection<object> ImageEntity;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "Reviewed.")]
        public User()
        {
            this.Blocked_Users = new HashSet<Blocked_Users>();
            this.Reviews = new HashSet<Review>();
            this.Rights = new HashSet<Right>();
            this.Trips = new HashSet<Trip>();
        }

        [Key]
        ////[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Last_Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(30)]
        public string Photo_Url { get; set; }

        //public ImageEntity image { get; set; }


        [Required]
        [StringLength(30)]
        public string Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Reviewed.")]
        public virtual ICollection<Blocked_Users> Blocked_Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Reviewed.")]
        public virtual ICollection<Review> Reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Reviewed.")]
        public virtual ICollection<Right> Rights { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Reviewed.")]
        public virtual ICollection<Trip> Trips { get; set; }

        public virtual ImageEntity image { get; set; }
    }
}
