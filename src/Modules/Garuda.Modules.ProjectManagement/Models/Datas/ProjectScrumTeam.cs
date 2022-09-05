// <copyright file="ProjectScrumTeam.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class ProjectScrumTeam : BaseModel, IEntity, IEntityRegister
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
        /// Gets or sets a value indicating whether gets or Sets for Project Owner Id.
        /// </summary>
        [Required]
        public string PoDeveloper { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Scrum Master Id.
        /// </summary>
        [Required]
        public Guid SmDeveloperId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for User.
        /// </summary>
        public Developer SmDeveloper { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProjectScrumTeam>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.ProjectDetail)
               .WithMany(e => e.ProjectScrumTeams)
               .HasForeignKey(e => e.ProjectId);

                entity.Property(e => e.PoDeveloper)
                .HasMaxLength(300)
                .IsRequired();

                entity.HasOne(e => e.SmDeveloper).WithMany()
                .HasForeignKey(e => e.SmDeveloperId);

                entity.ToTable("ProjectScrumTeams");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
