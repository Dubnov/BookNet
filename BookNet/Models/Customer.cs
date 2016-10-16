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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreationDate { get; set; }

        #endregion
        
        #region Navigate Properties

        public ICollection<Book> Books { get; set; } 

        #endregion
    }
}