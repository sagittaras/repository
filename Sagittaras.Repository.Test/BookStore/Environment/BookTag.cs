using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sagittaras.Repository.Test.BookStore.Environment
{
    public class BookTag
    {
        [NotMapped]
        public Guid Id
        {
            get => BookId;
            set => BookId = value;
        }

        [NotMapped]
        public int SecondId
        {
            get => TagId;
            set => TagId = value;
        }
        
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        
        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }
        
        public virtual Book Book { get; set; }
        public virtual Tag Tag { get; set; }
    }
}