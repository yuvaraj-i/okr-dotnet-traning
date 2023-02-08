using System;
using Microsoft.EntityFrameworkCore;
using okrDemoApp.Models;

namespace okrDemoApp.DBContex
{
	public class AppDbContex: DbContext
    {
        public AppDbContex() { }

        public AppDbContex(DbContextOptions<AppDbContex> options): base(options)
        {

        }

        public DbSet<Skill> skills { get; set; }
        public DbSet<SkillSetMapping> skillSetMappings { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<AccomplishmentModel> accomplishments { get; set; }
        public DbSet<ActivityLog> activityLogs { get; set; }
    }

}