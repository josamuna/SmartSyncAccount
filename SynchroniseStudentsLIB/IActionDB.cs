using System;
using System.Collections.Generic;

namespace SynchroniseStudentsLIB
{
    public interface IActionDB
    {
        void Execute(List<Queries> lstQueries, ServerType serveurType);
        int Execute(string strQuery, ServerType serveurType);
        List<Queries> LoadRecord(ServerType serveurType);
        int CoutRecord(ServerType serveurType);
    }
}
