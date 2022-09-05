// <copyright file="User.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.Common.Models.Datas.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.Common.Models.Datas
{
    public class User : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Fullname
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for IsActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for LastLogin
        /// </summary>
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for UserGroups
        /// </summary>
        public IList<UserGroup> UserGroups { get; set; } = new List<UserGroup>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for UserUnits
        /// </summary>
        public IList<UserUnit> UserUnits { get; set; } = new List<UserUnit>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                .HasMaxLength(50);

                entity.Property(e => e.Fullname)
                .HasMaxLength(100);

                entity.Property(e => e.Username)
                .HasMaxLength(100);

                entity.Property(e => e.Password);

                entity.Property(e => e.IsActive);

                entity.Property(e => e.LastLogin);

                entity.ToTable("Users");

                entity.HasData(UserSeeder.Seed());

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
