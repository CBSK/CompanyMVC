
using System.Data.Entity.ModelConfiguration;
using News.Models.Models;

namespace News.Models.EntityConfiguration
{
   public class UserConfiguration : EntityTypeConfiguration<Users>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            HasKey(x => x.UserID);
        }
    }
    
}
