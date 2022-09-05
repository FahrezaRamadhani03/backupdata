// <copyright file="City.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.ProjectManagement.Models.Datas.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{

    public class City : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [StringLength(maximumLength: 255)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Province Id.
        /// </summary>
        public Guid ProvinceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Province.
        /// </summary>
        public Province Province { get; set; }

        public IList<District> Districts { get; set; } = new List<District>();

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name);

                entity.Property(e => e.Code);

                entity.HasOne(e => e.Province)
                   .WithMany(e => e.Cities)
                   .HasForeignKey(e => e.ProvinceId);

                entity.ToTable("Cities");

                entity.HasData(CitySeeder.Seed());

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}