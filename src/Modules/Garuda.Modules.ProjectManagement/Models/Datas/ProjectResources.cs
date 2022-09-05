// <copyright file="ProjectResources.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class ProjectResources : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Id.
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Detail.
        /// </summary>
        public ProjectDetail ProjectDetail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Role Id.
        /// </summary>
        [Required]
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Detail.
        /// </summary>
        public DevelopmentRole DevelopmentRole { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Role Id.
        /// </summary>
        [StringLength(maximumLength: 50)]
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Qty.
        /// </summary>
        [DefaultValue(1)]
        [Required]
        public int Qty { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProjectResources>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ProjectId);

                entity.HasOne(e => e.ProjectDetail)
               .WithMany(e => e.ProjectResources)
               .HasForeignKey(e => e.ProjectId);

                entity.Property(e => e.RoleId);

                entity.HasOne(e => e.DevelopmentRole)
                .WithMany(e => e.ProjectResources)
                .HasForeignKey(e => e.RoleId);

                entity.Property(e => e.Level);

                entity.Property(e => e.Qty);

                entity.ToTable("ProjectResources");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
