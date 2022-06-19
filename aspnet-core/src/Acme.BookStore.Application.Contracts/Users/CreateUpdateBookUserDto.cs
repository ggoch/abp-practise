using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Users
{
    public class CreateUpdateBookUserDto
    {
        [Required]
        [StringLength(128)]
        public string Name { set; get; }

        [Required]
        public virtual string UserName { get; protected set; }

        [Required]
        public virtual string Surname { get; set; }
    }
}
