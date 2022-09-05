// <copyright file="Developer.cs" company="CV Garuda Infinity Kreasindo">
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
    public class Developer : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Fullname.
        /// </summary>
        [Required]
        public string Fullname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Employee Id.
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Employee.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Client Id.
        /// </summary>
        public int? ClientId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Client
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Client
        /// </summary>
        public decimal RatePerDay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Project Development Team
        /// </summary>
        public IList<ProjectDevelopmentTeam> ProjectDevelopmentTeams { get; set; } = new List<ProjectDevelopmentTeam>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Project Development Team
        /// </summary>
        public IList<DeveloperRole> DeveloperRoles { get; set; } = new List<DeveloperRole>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Developer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Fullname);

                entity.HasOne(e => e.Employee)
               .WithMany(e => e.Developers)
               .HasForeignKey(e => e.EmployeeId);

                entity.HasOne(e => e.Client)
               .WithMany(e => e.Developers)
               .HasForeignKey(e => e.ClientId);

                entity.Property(e => e.RatePerDay);

                entity.ToTable("Developers");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
