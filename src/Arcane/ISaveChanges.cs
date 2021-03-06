﻿using System.Threading.Tasks;

namespace Arcane
{
    /// <summary>
    /// Represents a persistance layer that can save changes.
    /// </summary>
    public interface ISaveChanges
    {
        /// <summary>
        /// Calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }

    /// <summary>
    /// Represents a persistance layer that can save changes.
    /// </summary>
    public interface ISaveChangesAsync : ISaveChanges
    {
        /// <summary>
        /// Asynchronously calls to the wrapped implementation to persist the changes made.
        /// </summary>
        /// <returns>A <see cref="Task"/> for later evaluation.</returns>
        Task<int> SaveChangesAsync();
    }
}