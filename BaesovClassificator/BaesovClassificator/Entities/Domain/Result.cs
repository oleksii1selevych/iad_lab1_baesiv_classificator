using System.ComponentModel.DataAnnotations.Schema;

namespace BaesovClassificator.Entities.Domain
{
    [Table("Results")]
    public class Result
    {
        [Column("ResultId")]
        public int Id { get; set; }
        public int TotalMessageCount { get; set; }
        public bool Correct { get; set; }
    }
}
