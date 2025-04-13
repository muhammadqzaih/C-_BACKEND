namespace EF007.ConfigurationByConvention.Entities;

public class Comment
{
    public int CommentId { get; set; }
    public int TweetId { get; set; }
    public int UserId { get; set; }
    public String CommentText { get; set; }
    public DateTime CreatedAt { get; set; }
}   