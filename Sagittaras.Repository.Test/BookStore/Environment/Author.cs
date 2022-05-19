using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Test.BookStore.Environment
{
    [Table(nameof(Author))]
    [Index(nameof(Email), IsUnique = true)]
    public class Author
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(128)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime Born { get; set; } = DateTime.Now;

        public virtual ICollection<Book>? Books { get; set; }
    }
}