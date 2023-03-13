using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    public class Videos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Title { get; set; }

        public String VideoPath { get; set; }
        public int UnitsId { get; set; }
        public virtual Units Units { get; set; }
        public Videos( string title, string videoPath)
        {

            Title = title;

            VideoPath = videoPath;


        }
    }
}
