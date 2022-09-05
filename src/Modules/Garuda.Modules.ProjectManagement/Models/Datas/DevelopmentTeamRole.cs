// <copyright file="DevelopmentTeamRole.cs" company="CV Garuda Infinity Kreasindo">
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
    public class DevelopmentTeamRole : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Development Team Id.
        /// </summary>
        public Guid DevelopmentTeamId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Development Team.
        /// </summary>
        public ProjectDevelopmentTeam ProjectDevelopmentTeam { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Role Id.
        /// </summary>
        [Required]
        public Guid DeveloperRoleId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Development Role.
        /// </summary>
        public DeveloperRole DeveloperRole { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<DevelopmentTeamRole>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.ProjectDevelopmentTeam)
               .WithMany(e => e.DevelopmentTeamRoles)
               .HasForeignKey(e => e.DevelopmentTeamId);

                entity.HasOne(e => e.DeveloperRole).WithMany()
                .HasForeignKey(e => e.DeveloperRoleId);

                entity.ToTable("DevelopmentTeamRoles");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
