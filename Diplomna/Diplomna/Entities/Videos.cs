using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    public class Videos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Title { get; set; }

        public Courses courseName { get; set; }
        public int VideosCount { get; set; }
        public String VideoPath { get; set; }

        public Videos( string title, int videosCount, string videoPath)
        {
           
            Title = title;
          
            VideosCount = videosCount;
            VideoPath = videoPath;
        }
    }
}
