using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sagittaras.Repository.Tests.BookStore.Environment
{
    public class BookTag
    {
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        
        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Tag Tag { get; set; } = null!;
    }
}