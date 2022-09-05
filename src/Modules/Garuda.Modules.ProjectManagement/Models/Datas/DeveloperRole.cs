// <copyright file="DeveloperRole.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.ProjectManagement.Models.Datas.Seeder;
using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class DeveloperRole : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [Required]
        public Guid DeveloperId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        public Developer Developer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Role Id.
        /// </summary>
        [Required]
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Development Role.
        /// </summary>
        public DevelopmentRole DevelopmentRole { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Level Id.
        /// </summary>
        public Guid? LevelId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Level.
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<DeveloperRole>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Developer)
                .WithMany(e => e.DeveloperRoles)
                .HasForeignKey(e => e.DeveloperId);

                entity.HasOne(e => e.DevelopmentRole)
                .WithMany()
                .HasForeignKey(e => e.RoleId);

                entity.HasOne(e => e.Level)
                .WithMany()
                .HasForeignKey(e => e.LevelId);

                entity.ToTable("DeveloperRoles");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
