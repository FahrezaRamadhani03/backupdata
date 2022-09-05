// <copyright file="Menu.cs" company="CV Garuda Infinity Kreasindo">
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
    public class Menu : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ParentId.
        /// </summary>
        public Guid? ParentId { get; set; } = Guid.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DisplayName.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DisplayOrder.
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Slug.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Level.
        /// </summary>
        public string IconClass { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        public IList<GroupMenuPermission> GroupMenuPermissions { get; set; } = new List<GroupMenuPermission>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e => e.Level)
                .HasMaxLength(500)
                .IsRequired();

                entity.Property(e => e.IconClass)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(e => e.DisplayOrder);

                entity.Property(e => e.Slug);

                entity.ToTable("Menus");

                entity.HasData(MenuSeeder.Seed());
            });
        }
    }
}
