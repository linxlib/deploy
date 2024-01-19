using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.LiteDB
{
    /// <summary>
    /// Represents a factory object for creating a <see cref="LiteDatabase"/> instance.
    /// </summary>
    public interface ILiteDatabaseFactory
    {
        /// <summary>
        /// Creates a new <see cref="LiteDatabase"/>instance.
        /// </summary>
        /// <returns>The <see cref="LiteDatabase"/> instance.</returns>
        LiteDatabase Create();
    }
}
