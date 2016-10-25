using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookNet.Models
{
    public class Customer
    {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]        
        public string ID { get; set; }

        [Required]
        [Display(Name = "First Name")]        
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]        
        public string City { get; set; }

        [Required]        
        public string Street { get; set; }
                
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        #endregion

        #region Ctor

        public Customer()
        {
            this.Books = new HashSet<Book>();
        }

        #endregion

        #region Navigate Properties

        public ICollection<Book> Books { get; set; } 

        #endregion
    }
}