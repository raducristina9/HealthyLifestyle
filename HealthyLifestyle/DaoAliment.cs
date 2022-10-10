using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class DaoAliment
    {
        SQLiteConnection connection;
        /*SQLiteAsyncConnection*/

        public DaoAliment()
        {
            string caleBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "healthy_lifestyle.db");
            connection = new SQLiteConnection(caleBD, false);
            connection.CreateTable<Aliment>();
        }

        public int adaugaAliment(Aliment aliment)
        {
            return connection.Insert(aliment);
        }

        public int adaugaListaAliment(List<Aliment> lista)
        {
            return connection.InsertAll(lista);
        }

        public List<Aliment> getAllAliments()
        {
            return connection.Query<Aliment>("SELECT * FROM Aliment");
        }

        public List<Aliment> getOneAlimentByName(String name)
        {
            return connection.Query<Aliment>("SELECT * FROM Aliment WHERE name = ?");
        }

        public void deleteAll()
        {
            connection.DeleteAll<Aliment>();

        }
    }
}
