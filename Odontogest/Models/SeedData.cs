using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odontogest.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new odontogestContext(
                serviceProvider.GetRequiredService<DbContextOptions<odontogestContext>>()))
            {
                if (context.Stores.Any())
                {
                    return;
                }
                context.Stores.AddRange(

                    new Store
                    {
                        NameStore = "Almacen1",
                        Location = "Bodega",
                        QuantityArticles = 25,
                        NewArticles = 12,
                        State = "Activo"
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
