using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookNet.Models
{
    public class Author
    {
        #region Properties

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Image { get; set; }

        public Genre Specialty { get; set; }

        #endregion

        #region Navigate Properties

        public ICollection<Book> Books { get; set; }

        #endregion
    }
}