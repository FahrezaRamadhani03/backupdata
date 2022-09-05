// <copyright file="AuditLog.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Database.Abstract.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Database.Framework.Models.Audits
{
    public class AuditLog : IEntity, IEntityRegister
    {
        public AuditLog()
        {
        }

        public Guid Id { get; set; }

        public string ClassName { get; set; }

        public string Action { get; set; }

        public string Description { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public string DeletedBy { get; set; }

        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("audit_logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.ClassName)
                    .HasColumnName("class_name");

                entity.Property(e => e.Action)
                    .HasColumnName("action");

                entity.Property(e => e.Description)
                    .HasColumnName("description");

                entity.Property(e => e.OldValue)
                    .HasColumnName("old_value");

                entity.Property(e => e.NewValue)
                    .HasColumnName("new_value");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by");
            });
        }
    }
}
