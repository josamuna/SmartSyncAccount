using System;

namespace SynchroniseStudentsLIB
{
    public class TypeServeur
    {
        private TypeServeur()
        {
        }

        private static TypeServeur _instance;

        public static TypeServeur Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new TypeServeur();
                return _instance; 
            }
        }

        private ServerType _myServerType;

        public ServerType MyServerType
        {
            get { return _myServerType; }
            set { _myServerType = value; }
        }
    }
}
