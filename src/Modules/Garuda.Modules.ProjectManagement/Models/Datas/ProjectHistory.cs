// <copyright file="ProjectHistory.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class ProjectHistory : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Id.
        /// </summary>
        [Required]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project.
        /// </summary>
        public ProjectDetail Project { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Status.
        /// </summary>
        [Required]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Remark.
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for ProjectHistories
        /// </summary>
        public IList<ProjectSPK> ProjectSPKs { get; set; } = new List<ProjectSPK>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProjectHistory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ProjectId);

                entity.HasOne(e => e.Project)
                .WithMany(e => e.ProjectHistories)
                .HasForeignKey(e => e.ProjectId);

                entity.Property(e => e.Status);

                entity.Property(e => e.Remark);

                entity.ToTable("ProjectHistories");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
