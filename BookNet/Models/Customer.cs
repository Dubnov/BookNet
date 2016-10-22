using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookNet.Models
{
    public class Customer
    {
        #region Properties

        [Key]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
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