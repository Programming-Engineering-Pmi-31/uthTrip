namespace uthTrip.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Blocked_Users = new HashSet<Blocked_Users>();
            Reviews = new HashSet<Review>();
            Rights = new HashSet<Right>();
            Trips = new HashSet<Trip>();
        }

        [Key]

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_ID { get; set; }

        [Required]
       
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name should be from  3 to 30 symbols")]

        public string First_Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Surname should be from  2 to 30 symbols")]
        public string Last_Name { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Username should be from  8 to 50 symbols")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password should be from  8 to 50 symbols")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]

        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(30)]
        public string Photo_Url { get; set; }

        [Required]
        [StringLength(30)]
        public string Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blocked_Users> Blocked_Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Right> Rights { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
