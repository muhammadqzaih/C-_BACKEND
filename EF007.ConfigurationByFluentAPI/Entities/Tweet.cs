namespace EF007.ConfigurationByConvention.Entities;

public class Tweet
{
    public int TweetId { get; set; }
    public int TweetBy { get; set; }
    public String TweetText { get; set; }
    public DateTime CreatedAt { get; set; }
}