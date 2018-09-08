
using System.Data.Entity.ModelConfiguration;
using News.Models.Models;

namespace News.Models.EntityConfiguration
{
   public class SecurityFeedsConfiguration : EntityTypeConfiguration<SecurityFeeds>
    {
        public SecurityFeedsConfiguration()
        {
            ToTable("SecurityFeeds");
            HasKey(x => x.SecurityFeedID);
        }
    }
}
