using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookNet.Models
{
    public enum Genre
    {
        Action,
        Horror,
        Mystery,
        Romance,
        Drama,
        Satire,
        Comedy,
        ScienceFiction,
        Adventure,
        Poetry,
        History        
    }

    public class Book
    {
        #region Properties

        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        public string Image { get; set; }

        [ForeignKey("Author")]
        public int AuthorID { get; set; }

        #endregion

        #region Navigate Properties

        public Author Author { get; set; }

        public ICollection<Customer> Customers { get; set; }

        #endregion
    }
}