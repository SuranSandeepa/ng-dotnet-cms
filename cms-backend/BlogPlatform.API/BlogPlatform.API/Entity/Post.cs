using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPlatform.API.Entity
{
    // This class represents the "Posts" table in the SQL database.
    [Table("Posts")]
    public class Post
    {
        public int Id { get; set; }// Primary Key
        public string Title { get; set; }
        public string Content { get; set; }
        public string FeaturedImage { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
