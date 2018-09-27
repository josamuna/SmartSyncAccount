using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;
using Npgsql;

namespace ManageConnexion
{
    public class ImplementConnection : IConnection
    {
        private ImplementConnection()
        {
        }
        private IDbConnection _conn;

        /// <summary>
        /// Property that encapsulate a representation of a connection to one Database
        /// </summary>
        public IDbConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }

        private List<IDbConnection> _conns = new List<IDbConnection>();

        /// <summary>
        /// List Property of all connections to database
        /// </summary>
        public List<IDbConnection> Conns
        {
            get { return _conns; }
            set { _conns = value; }
        }

        private static ImplementConnection instance;

        /// <summary>
        /// Allow to use public members of class
        /// </summary>
        public static ImplementConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new ImplementConnection();
                return instance;
            }
        }

        #region IConnection Members
        /// <summary>
        /// Allow to initialise Connection string of one Database.
        /// </summary>
        /// <param name="connection">Object of Connection class</param>
        /// <param name="connectionType">Object of ConnectionType Enumeration</param>
        /// <returns>Object IDbConnection</returns>
        public IDbConnection InitialiseSingleConnection(Connection connection, ConnectionType connectionType)
        {           
            switch (connectionType)
            {
                case ConnectionType.SQLServer:
                {
                    Conn = new SqlConnection(String.Format("Data Source={0};Initial catalog={1};User ID={2};Password={3}",
                        connection.Serveur, connection.Database, connection.User, connection.Password));
                    break;
                }
                case ConnectionType.MySQL:
                {
                    Conn = new MySqlConnection(String.Format("Server={0};Database={1};Uid={2};Pwd={3}",
                        connection.Serveur,connection.Database,connection.User,connection.Password));
                    break;
                }
                case ConnectionType.PostGreSQL:
                {
                    Conn = new NpgsqlConnection(String.Format("Data source={0};Uer ID={1};Password={2}",
                        connection.Database, connection.User, connection.Password));
                    break;
                }
                //case ConnectionType.Oracle:
                //{
                //    //Conn = new OracleConnection(String.Format("Server={0}:{1}/{2};Uid={3};Password={4};",
                //    //    connection.Serveur, connection.Port, connection.Database, connection.User, connection.Password));
                //    //Conn = new OracleConnection(String.Format("Server={0}:{1}/{2};Uid={3};Password={4};",
                //    //    connection.Serveur, connection.Port, connection.Database, connection.User, connection.Password));
                //    //Conn = new OracleConnection(String.Format("SERVER = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = {1}))(CONNECT_DATA = (SERVICE_NAME = {2})));",
                //    //    connection.Serveur, connection.Port, connection.Database, connection.User, connection.Password));
                //    Conn = new OracleConnection(String.Format("Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = {1}))(CONNECT_DATA = (SERVER=DEDICARED)(SERVICE_NAME = {2})));User ID={3};Password={4}",
                //        connection.Serveur, connection.Port, "OracleServiceXE", connection.User, connection.Password));
                //    break;
                //}
                case ConnectionType.Acces:
                {
                    Conn = new OleDbConnection(String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}{1}",
                        connection.Path,connection.Database));
                    break;
                }
            }
            return Conn;
        }

        /// <summary>
        /// Allow to initialise many Connection string of many Database and return them.
        /// </summary>
        /// <param name="connections">List Object of Connection class</param>
        /// <param name="connectionTypes">List Object of ConnectionType Enumeration</param>
        /// <returns>List Object IDbConnection</returns>
        public List<IDbConnection> InitialiseMultipleConnections(List<Connection> connections, List<ConnectionType> connectionTypes)
        {
            int i = 0;
            foreach (ConnectionType typeBD in connectionTypes)
            {
                switch (typeBD)
                {
                    case ConnectionType.SQLServer:
                    {
                        Conn = new SqlConnection(String.Format("Data Source={0};Initial catalog={1};User ID={2};Password={3}",
                            connections.ElementAt(i).Serveur, connections.ElementAt(i).Database, connections.ElementAt(i).User, connections.ElementAt(i).Password));
                        Conns.Add(Conn);
                        break;
                    }
                    case ConnectionType.MySQL:
                    {
                        Conn = new MySqlConnection(String.Format("Server={0};Database={1};Uid={2};Pwd={3}",
                            connections.ElementAt(i).Serveur, connections.ElementAt(i).Database, connections.ElementAt(i).User, connections.ElementAt(i).Password));
                        Conns.Add(Conn);
                        break;
                    }
                    case ConnectionType.PostGreSQL:
                    {
                        Conn = new NpgsqlConnection(String.Format("Server={0};Database={1};UID={2};Password={3};Port={4};",
                            connections.ElementAt(i).Serveur, connections.ElementAt(i).Database, connections.ElementAt(i).User, connections.ElementAt(i).Password, connections.ElementAt(i).Port));
                        Conns.Add(Conn);
                        break;
                    }
                    //case ConnectionType.Oracle:
                    //{
                    //    //Conn = new OracleConnection(String.Format("Server={0}:{1}/{2};Uid={3};Password={4};",
                    //    //    connection.Serveur, connection.Port, connection.Database, connection.User, connection.Password));
                    //    Conn = new OracleConnection(String.Format("SERVER = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = {1}))(CONNECT_DATA = (SERVICE_NAME = {2})));",
                    //        connections.ElementAt(i).Serveur, connections.ElementAt(i).Port, connections.ElementAt(i).Database, connections.ElementAt(i).User, connections.ElementAt(i).Password));
                    //    Conns.Add(Conn);
                    //    break;
                    //}
                    case ConnectionType.Acces:
                    {
                        Conn = new OleDbConnection(String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}{1}",
                            connections.ElementAt(i).Path, connections.ElementAt(i).Database));
                        Conns.Add(Conn);
                        break;
                    }
                }
                i++;
            }
            return Conns;
        }

        #endregion
    }
}
