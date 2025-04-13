using EF007.ConfigurationByConvention.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF007.ConfigurationUsingGroupingConfiguration.Data.Config;

public class TweetEntityTypeConfiguration: IEntityTypeConfiguration<Tweet>
{
    public void Configure(EntityTypeBuilder<Tweet> builder)
    {
        builder.ToTable("tblTweets");
    }
}