using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPlatform.API.Entity
{
    [Table("Tags")]
    public class Tag
    {
         public int Id { get; set; }
         public string Name { get; set; }
       
    }
}
