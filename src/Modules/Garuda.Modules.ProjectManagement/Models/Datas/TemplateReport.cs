// <copyright file="TemplateReport.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Garuda.Modules.ProjectManagement.Models.Datas.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.ProjectManagement.Models.Datas
{
    public class TemplateReport : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Body.
        /// </summary>
        public string Head { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Body.
        /// </summary>
        public string BodyDetail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Body.
        /// </summary>
        public string Footer { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<TemplateReport>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Subject)
                .IsRequired();

                entity.Property(e => e.Head);

                entity.Property(e => e.Body)
                .IsRequired();

                entity.Property(e => e.BodyDetail);

                entity.Property(e => e.Footer);

                entity.ToTable("TemplateReports");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
