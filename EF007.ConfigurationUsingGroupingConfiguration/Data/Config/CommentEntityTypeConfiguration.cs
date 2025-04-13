using EF007.ConfigurationByConvention.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF007.ConfigurationUsingGroupingConfiguration.Data.Config;

public class CommentEntityTypeConfiguration: IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("tblComments");
    }
}