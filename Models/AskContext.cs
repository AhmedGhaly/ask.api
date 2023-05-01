using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Xml;

namespace Social_website.Models
{
    public class AskContext : DbContext
    {
        public AskContext()
            : base("name=Ask.fm")
        {
        }

        public virtual DbSet<answers> Answers { get; set; }
        public virtual DbSet<questions> Questoins { get; set; }
        // public virtual DbSet<comments> Comments { get; set; }
        public virtual DbSet<users> Users { get; set; }

        public virtual DbSet<comments> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // one to many between users and questions
            modelBuilder.Entity<users>()
                .HasMany(u => u.Questions)
                .WithRequired(q => q.User)
                .HasForeignKey(q => q.UserId)
                .WillCascadeOnDelete(false);


            // on to many self realtion (users and folllows)
            modelBuilder.Entity<users>()
                .HasOptional(u => u.user)
                .WithMany(u => u.follow)
                .HasForeignKey(u => u.follow_id);

            // one to many between users and list of block users
            modelBuilder.Entity<users>()
                .HasOptional(u => u.block_user)
                .WithMany(u => u.block_users)
                .HasForeignKey(u => u.block_id);

            // one to one between question and answer
            modelBuilder.Entity<questions>()
                .HasOptional(u => u.Answers)
                .WithRequired(up => up.Questions);


            // one to many betweent answwers and answers
            //modelBuilder.Entity<answers>()
            //    .HasRequired(a => a.lover)
            //    .WithMany(u => u.loveAnswers)
            //    .HasForeignKey(a => a.lover_id);

            // one to many between users and answers
            modelBuilder.Entity<users>()
                .HasMany(u => u.Answers)
                .WithRequired(a => a.Users)
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);


            // one to many between users and answers comments
            //modelBuilder.Entity<users>()
            //    .HasMany(u => u.Comments)
            //    .WithRequired(c => c.Users)
            //    .HasForeignKey(c => c.UserId)
            //    .WillCascadeOnDelete(false);
        }

    }
}