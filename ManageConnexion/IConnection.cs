using System.Collections.Generic;
using System.Data;

namespace ManageConnexion
{
    /// <summary>
    /// Used to open one or many connections to a database (MS SQLServer,MySQL,PostGreSQL,Oracle or MS Access).
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Allow to initialise Connection string of one Database.
        /// </summary>
        /// <param name="connection">Object of Connection class</param>
        /// <param name="connectionType">Object of ConnectionType Enumeration</param>
        /// <returns>Object IDbConnection</returns>
        IDbConnection InitialiseSingleConnection(Connection connection, ConnectionType connectionType);
        ////IDbConnection InitialiseSingleConnection<T, U>(T connection, U connectionType);
        ////List<T> InitialiseMultipleConnections<T, U>(T connections, U connectionTypes);

        /// <summary>
        /// Allow to initialise many Connection string of many Database and return them.
        /// </summary>
        /// <param name="connections">List Object of Connection class</param>
        /// <param name="connectionTypes">List Object of ConnectionType Enumeration</param>
        /// <returns>List Object IDbConnection</returns>
        List<IDbConnection> InitialiseMultipleConnections(List<Connection> connections, List<ConnectionType> connectionTypes);
    }
}
