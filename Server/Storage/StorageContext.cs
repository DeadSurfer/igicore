﻿using System.Data.Entity;
using IgiCore.Models.Appearance;
using IgiCore.Models.Groups;
using IgiCore.Models.Player;
using IgiCore.SDK.Server.Storage.Contexts;
using MySql.Data.EntityFramework;

namespace IgiCore.Server.Storage
{
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public class StorageContext : EFContext
	{
		public DbSet<Session> Sessions { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<Group> Groups { get; set; }

		public DbSet<GroupMember> GroupMembers { get; set; }

		public DbSet<GroupRole> GroupRoles { get; set; }

		public DbSet<Style> Styles { get; set; }

		public StorageContext()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<StorageContext, Migrations.Configuration>());

			//this.Database.Log = m => new Logger().Debug(m);
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasIndex(u => u.SteamId).IsUnique();

			base.OnModelCreating(modelBuilder);
		}
	}
}
