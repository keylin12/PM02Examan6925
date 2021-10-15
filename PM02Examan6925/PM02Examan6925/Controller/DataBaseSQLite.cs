using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM02Examan6925.Models;
using System.Threading.Tasks;

namespace PM02Examan6925.Controller
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        public DataBaseSQLite(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Ubicacion>().Wait();
        }

        public Task<List<Ubicacion>> ObtenerListaUbicacion()
        {
            return db.Table<Ubicacion>().ToListAsync();
        }

        public Task<Ubicacion> ObtenerUbicacion(int pid)
        {
            return db.Table<Ubicacion>()
              .Where(i => i.id == pid)
              .FirstOrDefaultAsync();
        }

        public Task<int> GrabarUbicacion(Ubicacion ubicacion)
        {
            if (ubicacion.id != 0)
            {
                return db.UpdateAsync(ubicacion);
            }
            else
            {
                return db.InsertAsync(ubicacion);
            }
        }

        public Task<int> EliminarUbicacion(Ubicacion ubicacion)
        {
            return db.DeleteAsync(ubicacion);
        }

    }
}
