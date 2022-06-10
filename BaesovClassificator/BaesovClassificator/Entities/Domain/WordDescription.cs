using System.ComponentModel.DataAnnotations.Schema;

namespace BaesovClassificator.Entities.Domain
{
    [Table("Words")]
    public class WordDescription
    {
        [Column("WordId")]
        public int Id { get; set; }
        public string Word { get; set; } = null!;
        
        [ForeignKey(nameof(Classification))]
        public int ClassificationId { get; set; }
        public Classification? Classification { get; set; }
     }
}
