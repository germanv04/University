using UniversityWebAPI.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityWebAPI.Models
{
    public class Services 
    {
        //Buscar usuarios por email
        static public void searchUserByEmail()
        {

            var usuarios = new[] {
                new User {
                    Id = 1,
                    UserName ="Juan",
                    Email = "juan@test.com"
                },
                 new User {
                    Id = 2,
                    UserName ="Luis",
                    Email = "Luis@test.com"
                },
                  new User {
                    Id = 3,
                    UserName ="Carlos",
                    Email = "Carlos@test.com"
                }
            };

            //Buscar usuarios por email
            var seachByEmail = usuarios.Select(x => x).OrderBy(x => x.Email);
        }

        //Buscar alumnos con al menos 1 curso 
        static public void SeachAlumnsbyCourse()
        {
            var alumnos = new[] {

                new Student {

                    Id = 1,
                    Name ="Juan",
                    LastName ="perez",
                    Dob = DateTime.Now,

                    Courses = new[] {

                        new Course{

                            Id=1,
                            Name="Programacion 1",
                            ShortDescription = "Prendiendo metodos de linq",
                            Description = "ZZZ",
                            Level = Level.Advance,
                            Categories = new[] {

                                new Category{
                                    Name = "Tecnologia"
                                }
                            }


                        }
                    }
                },
                 new Student {

                    Id = 2,
                    Name ="Luis",
                    LastName ="perez",
                    Dob = DateTime.Now,

                    Courses = new[] {

                        new Course{

                            Id=2,
                            Name="Programacion 2",
                            ShortDescription = "Prendiendo metodos de linq",
                            Description = "ZZZ",
                            Level = Level.Advance,
                            Categories = new[] {

                                new Category{
                                    Name = "Tecnologia"
                                }
                            }


                        }
                    }
                 },
                  new Student {

                    Id = 3,
                    Name ="carlos",
                    LastName ="perez",
                    Dob = DateTime.Now,

                    Courses = new[] {

                        new Course{

                            Id=3,
                            Name="Programacion 3",
                            ShortDescription = "Prendiendo metodos de linq",
                            Description = "ZZZ",
                            Level = Level.Advance,
                            Categories = new[] {

                                new Category{
                                    Name = "Tecnologia"
                                }
                            }

                        }
                    }
                  }
            };

            //buscar alumnos que tengan al menos 1 curso

            var alumnosConUnCurso = alumnos.Select(alumn => alumn.Courses.Any(c => c != null));
        }

        //Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito
        static public void SeachCourseWithAlumns()
        {
            
            var course = new[] {

                new Course{
                    Id=1,
                    Name="Programacion 1",
                    ShortDescription = "Prendiendo metodos de linq",
                    Description = "ZZZ",
                    Level = Level.Advance,
                    Categories = new[] {

                        new Category{
                            Name = "Tecnologia"
                        }
                    }


                },

                 new Course{
                     Id=2,
                     Name="Programacion 2",
                     ShortDescription = "Prendiendo metodos de linq",
                     Description = "ZZZ",
                     Level = Level.Advance,
                     Categories = new[] {

                        new Category{
                            Name = "Tecnologia"
                        }
                     },
                     Students = new[] {
                        new Student {
                            Id = 1,
                            Name ="Juan",
                            LastName ="perez",
                            Dob = DateTime.Now,
                        },
                        new Student {
                            Id = 2,
                            Name ="luis",
                            LastName ="perez",
                            Dob = DateTime.Now,
                        },
                        new Student {
                            Id = 3,
                            Name ="carlos",
                            LastName ="perez",
                            Dob = DateTime.Now,
                        }

                     }       
                 },
                 new Course{
                     Id=3,
                     Name="Programacion 3",
                     ShortDescription = "Prendiendo metodos de linq",
                     Description = "ZZZ",
                     Level = Level.Advance,
                     Categories = new[] {

                         new Category{
                            Name = "Tecnologia"
                         }
                     },
                     Students = new[] {
                        new Student {
                            Id = 1,
                            Name ="Juan",
                            LastName ="perez",
                            Dob = DateTime.Now,
                        }
                     }
                 }
            };

            var courseWithStudents = course.Select(curso => curso.Students.Any(c => c != null));

        }
    }
}
