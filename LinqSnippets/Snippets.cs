using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqSnippets
{
    public class Snippets
    {

        //1. Basic Example
        static public void basicLinq()
        {
            string[] cars =
            {
                "VW Golf",
                "Vw California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };

            // **Hacer un select*from cars 

            var carList = from car in cars select car;
            //se puede leer como:  de "los elementos"(car) en cars selecciona "los elementos"(car)
            //(sino hay condicion, car es todos los elementos o uno si hay condicion) 

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

            // **Hacer Select*from cars where car = "Audi"

            var AudiList = from car in cars where car.Contains("Audi") select car;
            //se lee asi: de "los elementos"(car) en cars los que tengan "audi" seleccionalos 
            foreach (var audi in cars)
            {
                Console.WriteLine(audi);
            }

        }
     
        //2. Number Example usando .selec().where().orderby()
        static public void linqNumber()
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //** Each Number multiplied by 3
            //** take all number, but 9
            //** Order number by ascendin   g value

            var numberList = Numbers
                .Select(Num => (Num = Num * 3))
                .Where(num => num != 9)
                .OrderBy(num => num);
        }
        
        //3. SearchText: First, Last y except
        static public void searchExamples()
        {
            List<string> TextsList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            //3.1 first of the all element
            var first = TextsList.First();

            //first element that is "c"
            var textc = TextsList.First(e => e.Equals("c"));

            //first element that contains "j"
            var jtext = TextsList.First(text => text.Contains("j"));

            //first element that contains "z" or default
            var firstOrDefaultText = TextsList.FirstOrDefault(text => text.Contains("z"));// "" or "element z"

            //last element that contains "z" or default
            var lastOrDefaultText = TextsList.LastOrDefault(text => text.Contains("z"));

            //single values
            var uniqueText = TextsList.Single();
            var uniqueTextOrDefault = TextsList.SingleOrDefault();

            //sacar elementos no comunes de 2 listas con except
            int[] evenNumber = new int[] { 0, 2, 4, 6, 8};
            int[] otherNumber = new int[] { 0, 2, 6};

            var myEvenNumber = evenNumber.Except(otherNumber); //return {4, 8}



        }
    
        //4. Seleccionar multiples elementos y Any
        static public void selectMultiple()
        {
            //seleccionar todos los elementos juntos de una lista
            string[] myOpinions =
            {
                "Opinion 1",
                "Opinion 2",
                "Opinion 3"
            };

            var SelectOpinions = myOpinions.SelectMany(opinion => opinion.Split(","));


            //uso de las clases empresas y empleados
            var enterprises = new[]
            {
                new Enterprise  //Empresa 1
                {
                    Id= 1,
                    Name="Google",
                    Employes = new[]
                    {
                        new Employes //empleado 1
                        {
                            Id = 1,
                            Name = "German",
                            Email = "German@hotmail.com",
                            Salary = 3000

                        },

                        new Employes //empleado 2
                        {
                            Id = 2,
                            Name = "marcos",
                            Email = "marcos@hotmail.com",
                            Salary = 1000

                        },

                        new Employes //empleado 3
                        {
                            Id = 3,
                            Name = "juan",
                            Email = "juan@hotmail.com",
                            Salary = 4000

                        }
                    }
                },
                new Enterprise  //Empresa 2
                {
                    Id= 2,
                    Name="Apple",
                    Employes = new[]
                    {
                        new Employes //empleado 1
                        {
                            Id = 1,
                            Name = "luis",
                            Email = "luis@hotmail.com",
                            Salary = 5000

                        },

                        new Employes //empleado 2
                        {
                            Id = 2,
                            Name = "Alfonso",
                            Email = "alfonso@hotmail.com",
                            Salary = 1500

                        },

                        new Employes //empleado 3
                        {
                            Id = 3,
                            Name = "Alberto",
                            Email = "alberto@hotmail.com",
                            Salary = 4300

                        }
                    }
                }

            };

            //Obtener todos los empleados de todas las empresas
            var employesList = enterprises.SelectMany(enterprise => enterprise.Employes);

            //Saber si tenemos algo en alguna lista o esta vacia con true o false
            bool haveEnterprise = enterprises.Any();
            bool haveEmploye = enterprises.Any(enterprise => enterprise.Employes.Any());

            //todas tengan empleados de mas de 1000 euros
            bool haveEmployesWithSalary =
                enterprises.Any(enterprise => enterprise.Employes.Any(employe => employe.Salary > 1000));

        }

        //5. trabajando con colecciones y los joins
        static public void linqCollection()
        {
            var firstList = new List<string>() { "A", "B", "C" };
            var secondList = new List<string>() { "A", "C", "D" };

            //INNER JOIN

            //primera forma de join
            var commonResult = from element in firstList
                               join elementSecond in secondList
                               on element equals elementSecond
                               select new { element, elementSecond };

            //segunda forma
            var commonResult2 = firstList.Join(secondList, element => element,
                                                secondElement => secondElement,
                                               (element, secondElement) => new {element, secondElement });

            //OUTER JOIN - LEFT
            var outerJoinLeft = from element in firstList 
                                join elementSecond in secondList //seleccionamos datos de ambas lista
                                on element equals elementSecond// tomamos solo los que coinciden (join)
                                into temporalList   //lo añadimos en una lista temporal
                                from temporalElement in temporalList.DefaultIfEmpty() 
                                where element != temporalElement //tomamos del lado left(element del firt lista)
                                                                // todos los de elemento menos lo que coinciden
                                select new { Element = element }; //lo seleccionamos

            var outerJoinLeft2 = from element in firstList //seleccioname los elementos de la 1era lista
                                 from elementSecond in secondList
                                 .Where(secElemen => secElemen == element).DefaultIfEmpty() //los que coincidan con la 2da lista
                                 //el defaultEmpty nos ahorra el hacer una list temporal
                                 select new { Element = element };

            //OUTER JOIN - LEFT
            var outerJoinRight = from elementSecond in secondList
                                 join element in firstList
                                 on elementSecond equals element 
                                 into temporalList from temporalElement in temporalList.DefaultIfEmpty()
                                 where elementSecond != temporalElement
                                 select new {Element= elementSecond};

            //UNION
            var unionList = outerJoinLeft.Union(outerJoinRight);

        }

        //6. saltar y tomar elementos con SKIP y TAKE
        static public void skipTakeLinq()
        {
            var mylist = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            //****USO DE SKIP

            //se salta los 2 primeros valores
            var SkipTwoFirstValues = mylist.Skip(2); //R: {3, 4, 5, 6, 7, 8,9}

            //se salta los 2 ultimos valores
            var SkipTowLastValues = mylist.SkipLast(2); //R: {1, 2, 3, 4, 5, 6, 7}

            //salta los que tienen con condicion, en este caso mayores a 4
            var SkipWhileSmallerThan4 = mylist.SkipWhile(num => num > 4);  //R: { 5, 6, 7, 8, 9}


            //*****USO DE TAKE (lo contrario de skip, toma los saltados)

            //Toma los 2 primeros valores
            var TakeTwoFirstValues = mylist.Take(2); //R: {1, 2}

            //se salta los 2 ultimos valores
            var TakeTowLastValues = mylist.TakeLast(2); //R: {8, 9}

            //salta los que tienen con condicion, en este caso mayores a 4
            var TakeWhileSmallerThan4 = mylist.TakeWhile(num => num > 4);  //R: { 1, 2, 3}



        }



        /*********2DA FASE**********/

        //PAGING o PAGINACION usando Skip y Take juntos
        static public IEnumerable<T> GetPage<T> (IEnumerable<T> collection, int pageNumber, int ResultPerPage)
        {
            //lo que se quiere hacer es el pagina de 10 en 10 (buscar paginado en web en google )
            int starIndex = (pageNumber - 1) * ResultPerPage; //arroba cuantos paginado mostrar 
            //ejemplo si es pagina 1, 1 -1 = 0, starindex = 0 y no se salta nada.
            return collection.Skip(starIndex) ////arroja la coleccion saltandose el starIndex o los 10 primeros
                .Take(ResultPerPage); // toma los 10 elementos siguientes

            //se utiliza cuando se quieren tomar de 5 en 5 o de 10 en 10 datos
        }    

        //VARIABLES Let, Utilizacion o generacion de VARIABLES dentro de sentencias Linq
        static public void LinqVariable()
        {
            //para declarar variables dentro de las consultas e ir almacenando valores dentro de las mismas

            int [] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            //Sacar los elementos que esten por ensima de la media
            //Es decir una consulta del 1 -10, le sacaremos la media y tomaremos los que enten encima

            var aboveAverage = from number in numbers
                               let Average = numbers.Average() //Average significa Media
                               let nSquered = Math.Pow(number, 2) //elevamos al cuadrado
                               where nSquered > Average //la condicion para obtener los elementos
                               select number;

            Console.WriteLine("Media: {0}",numbers.Average());

            foreach (var number in aboveAverage)
            {
                Console.WriteLine("Number: {0} Squere:{1}",number, Math.Pow(number,2));
            }

        }

        //ZIP
        static public void LinqZip()
        {
            //un ZIP es como una cremallera, dos listas que se intercalan, estan como ligadas 
            //para hacer ZIP, las 2 listas deben tener el mismo numero de elementos

            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] StringNumbers = { "One", "Two", "Three", "Four", "Five" };
            IEnumerable<string> ZipNumbers = numbers.Zip(StringNumbers, (number, word) => word+"="+number);

            //R/ {1 = One, 2 = Two, Etc) o poddemos hacer otro tipo de operacion multiplicar 2 listas por ejemplo
           
        }

        //Repeat & Range
        static public void RepeatRangeLinq()
        {
            //son metodos de IEnumerable que se usan en operaciones linq
            //Se utiliza para generar secuencias simples

            //******RANGE
            //Generate collection from 1 - 100 element
            var First100 = Enumerable.Range(1,100); //generé una lista de 100 elementos del 1 al 100

            //select con la lista generada:
            var aboveAverage = from element in First100
                               select element;

            //*****REPEAT 
            // Repeat a value N times
            var FiveXs = Enumerable.Repeat("X", 5); //R: {"X","X","X","X","X"}

        }

        //Consultas con condiciones
        static public void StudentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name ="Martin",
                    grade = 90,
                    certified = true

                },
                new Student
                {
                    Id = 2,
                    Name ="Juan",
                    grade = 60,
                    certified = true

                },
                new Student
                {
                    Id = 3,
                    Name ="Carlos",
                    grade = 80,
                    certified = false

                },
                new Student
                {
                    Id = 4,
                    Name ="Mateo",
                    grade = 40,
                    certified = true

                },
                new Student
                {
                    Id = 5,
                    Name ="Pepe",
                    grade = 30,
                    certified = false

                }
            };

            //estudiantes que estan certificados
            var CertifiedStudents = from elemento in classRoom
                                    where elemento.certified
                                    select elemento;

            //estudiantes que no estan certificados
            var notCertifiedStudent = from element in classRoom
                                      where element.certified = false
                                      select element;
            //estudiantes con grado superior a 50 y que esten certificados
            var appovedStudentName = from element in classRoom
                                     where element.grade >= 50 && element.certified == true 
                                     select element.Name;



        }

        //ALL
        static public void LinqAll()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };

            //saber si todos los numeros son menores a 10
            bool allAreSmallerThat10 = numbers.All(s => s < 10); //R: true

            //saber si todos son mayores o = a 2
            bool allAreBiggerThat2 = numbers.All(x => x >= 2); //R: false

            //NOTA SI LA LISTA ESTÁ VACÍA, SIEMPRE NOS DEVOLVERÁ TRUE

        }
    
        //AGGREGATE
        static public void aggregateQueries()
        {
            //funciona como una secuencia acumulativa de funciones
            //cuya previa salida es la entrada de la sieguiente

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            //Sum all numbers
            var sumNumbers = numbers.Aggregate((prevSuma, current) => prevSuma + current);

            //funciona de la siguiente manera:
            //0, 1 => 1
            //1, 2 => 3
            //3, 3 => 6
            //etc
            //recordar que va recorriendo la lista, y va guardando el resultado
            //curren es el elemento recorrido, y prevsuma el resultado acumulado

            //Ejemplo 2
            string[] word = new string[] { "hello, " + "my " + "name " + "is " + "german"};

            string greeting = word.Aggregate((prevGreeting, current) => prevGreeting + current);
            //resultados:
            //"","hello," => "Hello,"
            //"hello,","my" => "hello, my"
            //"helo, my", name => "hello, my name"
            //etc.
        }

        //DISTINCT
        static public void distinctValue()
        {
            //si tenemos una lista con valores repetidos
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1};

            //y si queremos obtener los valores que no se repiten usamos distinct
                IEnumerable<int> distinctValues = numbers.Distinct(); //nos devuelve un IEnuemerable de tipo int
            
            //Nota: se puede usar para devolver por ejemplo estudiantes que tengan una nota en conceta
        }

        //GroupBy
        static public void groupByExamples()
        {
            //tenemos una lista de datos
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            //si queremos agrupar por los que tienen numeros pares usamos groupby
            var grouped = numbers.GroupBy(x => x%2 == 0);
            
            //esto nos devolveria 2 grupos, y se deberia de imprimir asi:.
            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); //R: 1, 3, 5...- 2, 4, 6, 8

                    //nos divide en 2 gropos los datos segun la condicion
                    //primero se imprimen los que no la cumplen, y luego los que la cumplen
                }

            }

            //Lista de estudiantes
            var classRoom = new[]
           {
                new Student
                {
                    Id = 1,
                    Name ="Martin",
                    grade = 90,
                    certified = true

                },
                new Student
                {
                    Id = 2,
                    Name ="Juan",
                    grade = 60,
                    certified = true

                },
                new Student
                {
                    Id = 3,
                    Name ="Carlos",
                    grade = 80,
                    certified = false

                },
                new Student
                {
                    Id = 4,
                    Name ="Mateo",
                    grade = 40,
                    certified = true

                },
                new Student
                {
                    Id = 5,
                    Name ="Pepe",
                    grade = 30,
                    certified = false

                }
            };

            //agruparlos en 2gruposl, los certificados y los que no estan certificados
            var certified = classRoom.GroupBy(student => student.certified);

            //Obtenermos 2 grupos:
            //1. Los no certificado
            //2. Los certificado

            foreach(var group in certified)
            {
                Console.WriteLine("------{0}------",group.Key); //clave por la que se esta agrupando
                foreach (var value in group)
                {
                    Console.WriteLine(value);
                }
            }
        }

        static public void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id=1,
                    Title = "My Post",
                    Content = "Conteniedo de mi post",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment
                        {
                            Id=1,
                            Created= DateTime.Now,
                            Title = "my comment 1",
                            content = "my comment's content 1"
                        },
                        new Comment
                        {
                            Id=2,
                            Created= DateTime.Now,
                            Title = "my comment 2",
                            content = "my comment's content 2"
                        },
                        new Comment
                        {
                            Id=3,
                            Created= DateTime.Now,
                            Title = "my comment 3",
                            content = "my comment's content 3"
                        }
                    }
                },
                new Post()
                {
                    Id=2,
                    Title = "My Postc2",
                    Content = "Conteniedo de mi post 2",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment
                        {
                            Id=4,
                            Created= DateTime.Now,
                            Title = "my comment 1",
                            content = "my comment's content 1"
                        },
                        new Comment
                        {
                            Id=5,
                            Created= DateTime.Now,
                            Title = "my comment 2",
                            content = "my comment's content 2"
                        },
                        new Comment
                        {
                            Id=6,
                            Created= DateTime.Now,
                            Title = "my comment 3",
                            content = "my comment's content 3"
                        }
                    }
                },
                new Post()
                {
                    Id=3,
                    Title = "My Post 3",
                    Content = "Conteniedo de mi post 3",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment
                        {
                            Id=7,
                            Created= DateTime.Now,
                            Title = "my comment 1",
                            content = "my comment's content 1"
                        },
                        new Comment
                        {
                            Id=8,
                            Created= DateTime.Now,
                            Title = "my comment 2",
                            content = "my comment's content 2"
                        },
                        new Comment
                        {
                            Id=9,
                            Created= DateTime.Now,
                            Title = "my comment 3",
                            content = "my comment's content 3"
                        }
                    }
                }
            };

            //Sacar todos los comentarios que contenga contenido en un post
            var commentsWithContent = posts.SelectMany(
                post => post.Comments, 
                (post, comment) => new { PostId = post.Id, Content = comment.content} );

        }




        //***************************************************************************************************
    }
}