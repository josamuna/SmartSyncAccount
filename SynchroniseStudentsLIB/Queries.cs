using System;

namespace SynchroniseStudentsLIB
{
    public class Queries
    {
        public Queries()
        {
        }

        private int id;

        public int Id
        {
            get { return id; }
            set 
            {
                if (value <= 0)
                    id = 1;
                else 
                    id = value; 
            }
        }
        private string requete;

        public string Requete
        {
            get { return requete; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Les requêtes vides nes sont pas autorisées !!!");
                else 
                    requete = value; 
            }
        }
    }
}
