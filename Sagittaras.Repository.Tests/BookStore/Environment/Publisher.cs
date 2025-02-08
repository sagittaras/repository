using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Sagittaras.Repository.Tests.BookStore.Environment
{
    [Table(nameof(Publisher))]
    [Index(nameof(Name), IsUnique = true)]
    public class Publisher 
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Book>? Books { get; set; }
    }
}