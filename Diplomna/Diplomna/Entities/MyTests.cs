using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    public class MyTests
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float Score { get; set; }
        public int coursId { get; set; }
        public int TestId { get; set; }
        public string UserName { get; set; }
        public virtual Users User { get; set; }
    }
}
