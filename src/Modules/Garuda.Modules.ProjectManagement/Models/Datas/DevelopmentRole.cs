// <copyright file="DevelopmentRole.cs" company="CV Garuda Infinity Kreasindo">
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
    public class DevelopmentRole : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Leader.
        /// </summary>
        [DefaultValue(false)]
        public bool Leader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Level.
        /// </summary>
        [JsonField]
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        public IList<ProjectResources> ProjectResources { get; set; } = new List<ProjectResources>();

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<DevelopmentRole>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name);

                entity.HasIndex(e => e.Code);

                entity.Property(e => e.Leader);

                entity.Property(e => e.Level).HasJsonValueConversion();

                entity.ToTable("DevelopmentRoles");

                entity.HasData(DevelopmentRoleSeeder.Seed());

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
