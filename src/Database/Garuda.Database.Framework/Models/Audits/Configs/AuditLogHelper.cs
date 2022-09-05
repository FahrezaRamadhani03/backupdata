// <copyright file="AuditLogHelper.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Garuda.Database.Framework.Models.Audits.Configs
{
    public class AuditLogHelper : RepositoryBase<AuditLog>
    {
        private readonly Storage db;

        public AuditLogHelper(Storage db)
        {
            this.db = db;
        }

        public void AddAuditLogs(string userName)
        {
            (db.StorageContext as DbContext).ChangeTracker.DetectChanges();
            List<AuditLogEntry> auditEntries = new List<AuditLogEntry>();
            foreach (EntityEntry entry in (db.StorageContext as DbContext).ChangeTracker.Entries())
            {
                if (entry.Entity is AuditLog
                    || entry.State == EntityState.Detached
                    || entry.State == EntityState.Unchanged)
                {
                    continue;
                }

                var auditEntry = new AuditLogEntry(entry, userName);
                auditEntries.Add(auditEntry);
            }

            if (auditEntries.Any())
            {
                var logs = auditEntries.Select(x => x.ToAudit());
                this.SetStorageContext(db.StorageContext);
                this.dbSet.AddRange(logs);
            }
        }
    }
}
