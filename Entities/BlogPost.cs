namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class BlogPost
{
    public int Id { get; set; }
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false)] // or false
    public string Title { get; set; }
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false)] // or false
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

}