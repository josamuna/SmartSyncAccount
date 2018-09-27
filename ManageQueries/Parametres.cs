using System.Data;

namespace ManageUtilities
{
    public class Parametres
    {

        private Parametres()
        {
        }

        private static Parametres instance;

        /// <summary>
        /// Allow to use public members of class
        /// </summary>
        public static Parametres Instance
        {
            get 
            {
                if (instance == null)
                    instance = new Parametres();
                return Parametres.instance; 
            }
        }

        /// <summary>
        /// Allow to add parameter to a command for a execution of sql query
        /// </summary>
        /// <param name="command">Object IDbCommand</param>
        /// <param name="nomParametre">string parameter</param>
        /// <param name="taille">Lenght of parameter</param>
        /// <param name="type">Object DbType</param>
        /// <param name="valeur">Value of parameter</param>
        /// <returns>Object IDbDataParameter</returns>
        public IDbDataParameter AjouterParametre(IDbCommand command,string nomParametre,int taille,DbType type,object valeur)
        {
            IDbDataParameter param = command.CreateParameter();

            param.ParameterName = nomParametre;
            param.Size = taille;
            param.DbType = type;
            param.Value = valeur;

            return param;            
        }
    }
}
