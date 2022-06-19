using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Books
{
    public class CreateUpdateBookDto
    {
        [Required]
        [StringLength(128)]
        public string Name { set; get; }

        [Required]
        public BookType Type { set; get; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { set; get; } = DateTime.Now;

        [Required]
        public float Price { set; get; }
    }
}
