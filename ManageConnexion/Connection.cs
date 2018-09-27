using System;

namespace ManageConnexion
{
    /// <summary>
    /// Allow to specified all values for accessing Database ressources.
    /// </summary>
    public class Connection
    {
        public Connection()
        {
        }
        private string _serveur = "localhost";

        /// <summary>
        /// Property that specifie the server name or IP adress.
        /// </summary>
        public string Serveur
        {
            get { return _serveur; }
            set { _serveur = value; }
        }

        /// <summary>
        /// Propety that specifie Database name.
        /// </summary>
        private string _database = "database";

        public string Database
        {
            get { return _database; }
            set { _database = value; }
        }

        private string _user = "user";

        /// <summary>
        /// Property that specifie the username.
        /// </summary>
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        /// <summary>
        /// Property that specifie the password of access to Database.
        /// </summary>
        private string _password = "password";

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string path = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Property that specifie the path of Database (Used for Access Database only).
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private int _port = 0;


        /// <summary>
        /// Property that specifie the port number like 3306 (Default port number for MySQL) 
        /// or 5432 (Default port number for PostGreSQL)
        /// </summary>
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
    }
}
