namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class BlogPostData
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

}