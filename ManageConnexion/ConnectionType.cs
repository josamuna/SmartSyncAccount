using System;

namespace ManageConnexion
{
    /// <summary>
    /// Allow to specifie Database type 
    /// (SQL Server, MySQLm PostGreSQL, Oracle or Access)
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// SQL Server Database type
        /// </summary>
        SQLServer,
        /// <summary>
        /// MySQL Database type
        /// </summary>
        MySQL,
        /// <summary>
        /// PostGreSQL Database type
        /// </summary>
        PostGreSQL,
        /// <summary>
        /// Not completelly implemented
        /// </summary>
        Oracle,
        /// <summary>
        /// Access Database type
        /// </summary>
        Acces
    }
}
