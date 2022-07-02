using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Services
    {
        //Buscar usuarios por email
        static public void searchWithOrdeBy()
        {
            var users = new[] {
                new Employes
                {
                    Id = 1,
                    Name = "Juan",
                    Edad = 18,
                    Salary = 3000,
                    Email = "Juan@text.com"
                },
                new Employes
                {
                    Id = 2,
                    Name = "Luis",
                    Edad = 20,
                    Salary = 2000,
                    Email = "Luis@text.com"
                },
                new Employes
                {
                    Id = 3,
                    Name = "carlos",
                    Edad = 17,
                    Salary = 4000,
                    Email = "carlos@text.com"
                },
            };

            //Buscar usuarios por email
            var seachByEmail = users.Select(x => x).OrderBy(x => x.Email);

            //Buscar alumnos mayores de edad 
            var seachAdult = users.Select(x => x).Where(x => x.Edad > 18);

        }
    }
}
