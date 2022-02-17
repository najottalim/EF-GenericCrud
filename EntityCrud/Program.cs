using EntityCrud.Data.Contexts;
using EntityCrud.Data.IRepository;
using EntityCrud.Data.Repository;
using EntityCrud.Models;
using System;
using System.Threading.Tasks;

namespace EntityCrud
{
    internal class Program
    {
        public static NajotTalimDbContext najotTalimDbContext = new ();
        static async Task Main(string[] args)
        {
            IGenericCrudRepository<Client> _clientDb = new GenericCrudRepository<Client>(najotTalimDbContext);

            var clients = await _clientDb.GetAllAsync();

            foreach (var item in clients)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
