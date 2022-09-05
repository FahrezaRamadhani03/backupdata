// <copyright file="AuditLogEntry.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Garuda.Database.Framework.Models.Audits.Configs
{
    public class AuditLogEntry
    {
        public EntityEntry Entry { get; }

        public string Action { get; set; }

        public string AuditUser { get; set; }

        public string ClassName { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string DeletedBy { get; set; }

        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();

        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();

        public AuditLogEntry(EntityEntry entry, string auditUser)
        {
            Entry = entry;
            AuditUser = auditUser;
            SetChanges();
        }

        private void SetChanges()
        {
            ClassName = Entry.Metadata.Name;
            foreach (PropertyEntry property in Entry.Properties)
            {
                string propertyName = property.Metadata.Name;

                switch (Entry.State)
                {
                    case EntityState.Added:
                        NewValues[propertyName] = property.CurrentValue;
                        Action = "CREATE";
                        UpdatedAt = DateTime.Now;
                        UpdatedBy = AuditUser;
                        break;

                    case EntityState.Deleted:
                        OldValues[propertyName] = property.OriginalValue;
                        Action = "DELETE";
                        DeletedAt = DateTime.Now;
                        DeletedBy = AuditUser;
                        break;

                    case EntityState.Modified:
                        if (property.IsModified)
                        {
                            OldValues[propertyName] = property.OriginalValue;
                            NewValues[propertyName] = property.CurrentValue;
                            Action = "UPDATE";
                            UpdatedAt = DateTime.Now;
                            UpdatedBy = AuditUser;
                        }

                        break;
                }
            }
        }

        public AuditLog ToAudit()
        {
            var audit = new AuditLog
            {
                Id = Guid.NewGuid(),
                ClassName = ClassName,
                Action = Action,
                Description = "",
                OldValue = OldValues.Count == 0
                    ? null
                    : JsonConvert.SerializeObject(OldValues),
                NewValue = NewValues.Count == 0
                    ? null
                    : JsonConvert.SerializeObject(NewValues),
                CreatedAt = DateTime.Now,
                UpdatedAt = UpdatedAt.Value,
                DeletedAt = DeletedAt,
                CreatedBy = AuditUser,
                UpdatedBy = UpdatedBy,
                DeletedBy = DeletedBy,
            };

            return audit;
        }
    }
}
