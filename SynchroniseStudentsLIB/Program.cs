using System;
using System.Collections.Generic;

using System.Data;

namespace SynchroniseStudentsLIB
{
    class Program
    {
        static void Main(string[] args)
        {
            //On Charge les deux chaines de connexion pour SQLServer et MySQL
            //////try
            //////{
            //////    //SQL Server
            //////ConnectSQLServer.Instance.Initialise();
            //////ConnectSQLServer.Instance.OpenConnection();
            //////    IActionDB actionSQL = new ImplementActionDBSQLServer();

            //////    List<Queries> q = new List<Queries>();
            //////    q = actionSQL.LoadRecord();

            //////    foreach (Queries qr in q)
            //////    {
            //////        Console.WriteLine("qr.Id = {0} et qr.Requete = {1}",qr.Id, qr.Requete);
            //////        action.PutLogMessage(string.Format("qr1.Id = {0} et qr1.Requete = {1}", qr.Id, qr.Requete));
            //////    }
            //////    Console.WriteLine("\n\n=================================================================\n\n");
            //////    //MySQL
            //////    ConnectMySQL.Instance.Initialise();
            //////    ConnectMySQL.Instance.OpenConnection();
            //////    IActionDB actionMySQL = new ImplementActionDBMySQL();

            //////    List<Queries> q1 = new List<Queries>();
            //////    q1 = actionMySQL.LoadRecord();

            //////    foreach (Queries qr in q1)
            //////    {
            //////        Console.WriteLine("qr.Id = {0} et qr.Requete = {1}", qr.Id, qr.Requete);
            //////        action.PutLogMessage(string.Format("qr2.Id = {0} et qr2.Requete = {1}", qr.Id, qr.Requete));
            //////    }

            //////    Console.ReadLine();
            //////}
            //////catch (Exception ex)
            //////{
            //////    action.PutLogMessage(DateTime.Now + " : Echec de l'initialisation des paramètres de connexion à la BD : " + ex.Message);
            //////}
        }
    }
}
