using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sagittaras.Repository.Tests.BookStore.Environment
{
    [Table(nameof(Tag))]
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}