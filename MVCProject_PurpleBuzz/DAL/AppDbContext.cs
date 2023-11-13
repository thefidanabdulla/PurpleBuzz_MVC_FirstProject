using System;
using Microsoft.EntityFrameworkCore;
using MVCProject_PurpleBuzz.Models;

namespace MVCProject_PurpleBuzz.DAL
{
	public class AppDbContext : DbContext
    {
		public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
		{

		}

		public DbSet<ProjectComponent> ProjectComponents { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Component> Components { get; set; }
		public DbSet<RecentWork> RecentWorks{ get; set; }
		public DbSet<CategoryComponent> CategoryComponents{ get; set; }
		public DbSet<ObjectiveComponent> ObjectiveComponents { get; set; }
		public DbSet<TeamMember> TeamMembers{ get; set; }
		
		


	}
}

