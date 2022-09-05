// <copyright file="ProjectDevelopmentTeam.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class ProjectDevelopmentTeam : BaseModel, IEntity, IEntityRegister
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
        /// Gets or sets a value indicating whether gets or Sets for Term No.
        /// </summary>
        [Required]
        public Guid DeveloperId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for User.
        /// </summary>
        public Developer Developer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Man a day.
        /// </summary>
        [Required]
        public decimal ManADay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Start Date.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for End Date.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Mandays.
        /// </summary>
        [Required]
        public decimal ManDays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Leader.
        /// </summary>
        [Required]
        public bool IsLeader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Leader.
        /// </summary>
        public IList<DevelopmentTeamRole> DevelopmentTeamRoles { get; set; } = new List<DevelopmentTeamRole>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProjectDevelopmentTeam>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.ProjectDetail)
               .WithMany(e => e.ProjectDevelopmentTeams)
               .HasForeignKey(e => e.ProjectId);

                entity.HasOne(e => e.Developer)
                .WithMany(e => e.ProjectDevelopmentTeams)
                .HasForeignKey(e => e.DeveloperId);

                entity.Property(e => e.ManADay);

                entity.Property(e => e.StartDate);

                entity.Property(e => e.EndDate);

                entity.Property(e => e.ManDays);

                entity.Property(e => e.IsLeader);

                entity.ToTable("ProjectDevelopmentTeams");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
