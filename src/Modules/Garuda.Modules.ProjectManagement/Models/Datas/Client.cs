// <copyright file="Client.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class Client : BaseModel, IEntity, IEntityRegister
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string ZipCode { get; set; }

        public string PICName { get; set; }

        public string PICPhone { get; set; }

        public string PICEmail { get; set; }

        public string InvoiceName { get; set; }

        public string InvoiceEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectResources.
        /// </summary>
        public IList<ProjectDetail> ProjectDetails { get; set; } = new List<ProjectDetail>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Project Development Team
        /// </summary>
        public IList<Developer> Developers { get; set; } = new List<Developer>();

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e => e.District)
                .HasMaxLength(100);

                entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e => e.ZipCode)
                .HasMaxLength(50);

                entity.Property(e => e.PICName)
                .HasMaxLength(255);

                entity.Property(e => e.PICPhone)
                .HasMaxLength(50);

                entity.Property(e => e.PICEmail)
                .HasMaxLength(255);

                entity.Property(e => e.InvoiceEmail)
                .HasMaxLength(255);

                entity.Property(e => e.InvoiceName)
                .HasMaxLength(255);

                entity.ToTable("Client");

                entity.HasQueryFilter(x => x.DeletedDate == null);
            });
        }
    }
}
