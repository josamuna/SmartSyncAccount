using System;

namespace SynchroniseStudentsLIB
{
    public class Utilitaires
    {
        private Utilitaires()
        {
        }

        private static Utilitaires _instance;

        public static Utilitaires Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Utilitaires();
                return _instance; 
            }
        }

        private string _path;

        public string Path
        {
            get { return _path; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Veuillez specifier un fichier texte valide svp !!!");
                else 
                    _path = value; 
            }
        }

        //private string _filename;

        //public string Filename
        //{
        //    get { return _filename; }
        //    set
        //    {
        //        if (string.IsNullOrEmpty(value))
        //            throw new Exception("Veuillez specifier un nom de fichier valide svp !!!");
        //        else
        //            _filename = value;
        //    }
        //}
    }
}
