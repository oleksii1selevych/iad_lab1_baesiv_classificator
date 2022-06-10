using System.ComponentModel.DataAnnotations.Schema;

namespace BaesovClassificator.Entities.Domain
{
    [Table("Classifications")]
    public class Classification
    {
        [Column("ClassificationId")]
        public int Id { get; set; }
        public string ClassificationName { get; set; } = null!;
        public int MessagesCount { get; set; }
        ICollection<WordDescription>? Words { get; set; }
    }
}
