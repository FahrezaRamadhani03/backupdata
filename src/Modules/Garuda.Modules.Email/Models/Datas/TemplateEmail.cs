// <copyright file="TemplateEmail.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Framework;
using Garuda.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Modules.Email.Models.Datas
{
    public class TemplateEmail : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Subject.
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Body.
        /// </summary>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Footer.
        /// </summary>
        public string Footer { get; set; }

        /// <summary>
        /// Model builder to create it own model to declare field and relation.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<TemplateEmail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Subject)
                .IsRequired();

                entity.Property(e => e.Body)
                .IsRequired();

                entity.Property(e => e.Footer);

                entity.ToTable("TemplateEmails");

                entity.HasQueryFilter(e => e.DeletedDate == null);
            });
        }
    }
}
