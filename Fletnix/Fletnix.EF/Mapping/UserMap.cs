using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            Property(u => u.Id).IsUnicode(false);

            HasOptional(u => u.Subscription).WithRequired(s => s.User).Map(m => m.MapKey("UserId")).WillCascadeOnDelete();
        }
    }
}