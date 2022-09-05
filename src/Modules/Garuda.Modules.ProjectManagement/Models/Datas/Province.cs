// <copyright file="Province.cs" company="CV Garuda Infinity Kreasindo">
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
    public class Province : BaseModel, IEntity, IEntityRegister
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
        /// Gets or sets a value indicating whether gets or Sets for Country Id.
        /// </summary>
        public Guid CountryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Country.
        /// </summary>
        public Country Country { get; set; }

        public IList<City> Cities { get; set; } = new List<City>();

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name);

                entity.Property(e => e.Code);

                entity.ToTable("Provinces");

                entity.HasOne(e => e.Country)
                  .WithMany(e => e.Provinces)
                  .HasForeignKey(e => e.CountryId);

                entity.HasData(ProvinceSeeder.Seed());

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
