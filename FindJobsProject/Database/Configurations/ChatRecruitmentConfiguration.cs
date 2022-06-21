using FindJobsProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindJobsProject.Database.Configurations
{
    public class ChatRecruitmentConfiguration : IEntityTypeConfiguration<ChatRecruitment>
    {
        public void Configure(EntityTypeBuilder<ChatRecruitment> builder)
        {
            builder.ToTable("ChatRecruitment").HasKey(sc => sc.IdChat);

            builder.HasOne<AppUser>(x => x.Sender)
                    .WithMany(g => g.SentMessages)
                    .HasForeignKey(x => x.IdSender)
                    .OnDelete(DeleteBehavior.Cascade)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            
            builder.HasOne<AppUser>(x => x.Receiver)
                    .WithMany(g => g.ReceivedMessages)
                    .HasForeignKey(x => x.IdReceiver)
                    .OnDelete(DeleteBehavior.Cascade)
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
