using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sagittaras.Repository.Tests.BookStore.Environment;

[Table(nameof(Book))]
public class Book
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    [ForeignKey(nameof(Author))]
    public Guid AuthorId { get; set; }

    [Required]
    [ForeignKey(nameof(Publisher))]
    public Guid PublisherId { get; set; }

    public virtual Author? Author { get; set; }
    public virtual Publisher? Publisher { get; set; }
}