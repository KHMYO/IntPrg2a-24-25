using Site1.Models;

namespace Site1.Data
{
    public class MockData
    {
        public static List<Person> PersonList { get; set; } = new List<Person> {

                new Person{ Id=1,
                        Name="Ali",
                        Lastname="Yılmaz",
                        BirthPlace="İstanbul" },
                new Person{ Id=2,
                        Name="Ayşe",
                        Lastname="Hak",
                        BirthPlace="Ankara" },
                new Person{ Id=3,
                        Name="Veli",
                        Lastname="Türk",
                        BirthPlace="Bursa" },

            };
        


    }
}
