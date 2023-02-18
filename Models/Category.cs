

using System.ComponentModel.DataAnnotations;

namespace BulkybooksWeb.Models;
public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [System.ComponentModel.DisplayName("Display Order")]
    [Range(1,100,ErrorMessage ="Value must be between 1 and 100")]
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}