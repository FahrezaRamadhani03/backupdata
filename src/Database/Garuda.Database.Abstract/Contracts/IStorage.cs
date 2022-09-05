// <copyright file="IStorage.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;

namespace Garuda.Database.Abstract.Contracts
{
    /// <summary>
    /// IStorage.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Gets Storage Context.
        /// </summary>
        IStorageContext StorageContext { get; }

        /// <summary>
        /// GetRepository where T is table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetRepository<T>()
            where T : IRepository;

        /// <summary>
        /// Save transact.
        /// </summary>
        void Save();

        /// <summary>
        /// Save transact async.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SaveAsync();
    }
}