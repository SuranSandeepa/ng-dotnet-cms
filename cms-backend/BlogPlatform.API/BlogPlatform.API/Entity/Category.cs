using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPlatform.API.Entity
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
