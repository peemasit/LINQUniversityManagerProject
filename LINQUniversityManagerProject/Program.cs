using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQUniversityManagerProject {
    class Program {
        static void Main(string[] args) {
            UniversityManeger um = new UniversityManeger();
            um.MaleStudent();
            um.FemaleStudent();
            um.SortStudentsByAge();
            um.AllStudentsFromUniversity(1);
            um.StudentAndUniversityNameCollection();
            Console.ReadKey();
        }
    }

    class UniversityManeger {
        public List<University> universities;
        public List<Student> students;

        public UniversityManeger() {
            universities = new List<University>();
            students = new List<Student>();
            universities.Add(new University { Id = 1, Name = "Cambridge" });
            universities.Add(new University { Id = 2, Name = "Stanford" });

            students.Add(new Student { Id = 1, Name = "Peem", Gender = "male", Age = 18, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Carol", Gender = "female", Age = 20, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Daryl", Gender = "male", Age = 22, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "Sansa", Gender = "female", Age = 19, UniversityId = 1 });
            students.Add(new Student { Id = 5, Name = "John", Gender = "male", Age = 17, UniversityId = 2 });
        }
        public void MaleStudent() {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;
            Console.WriteLine("Male Students : ");
            foreach (Student students in maleStudents) {
                students.Print();
            }
        }

        public void FemaleStudent() {
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "female" select student;
            Console.WriteLine("Female Students :");
            foreach (Student students in femaleStudents) {
                students.Print();
            }
        }

        public void SortStudentsByAge() {
            var sortedStudents = from student in students orderby student.Age select student;
            Console.WriteLine("Student sorted by Age:");
            foreach (Student student in sortedStudents) {
                student.Print();
            }
        }

        public void AllStudentsFromUniversity(int univesityId) {
            IEnumerable<Student> myStudent = from student in students join university in universities on student.UniversityId equals university.Id
                                             where university.Id == univesityId select student;
            if (univesityId == 1) {
                Console.WriteLine("Student from Cambridge");
            } else if (univesityId == 2) {
                Console.WriteLine("Student from Stanford");
            }
            foreach (Student student in myStudent) {
                student.Print();
            }
        }

        public void StudentAndUniversityNameCollection() {
            var newCollection = from student in students join university in universities on student.UniversityId equals university.Id
                                orderby student.Name select new { Studentname = student.Name, UniversityName = university.Name };
            Console.WriteLine("New Collection :");
            foreach (var col in newCollection) {
                Console.WriteLine($"Student {col.Studentname} from University {col.UniversityName}");
            }
        }
    }

    class University {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Print() {
            Console.WriteLine($"University {Name} with id {Id}");
        }
    }

    class Student {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int UniversityId { get; set; }

        public void Print() {
            Console.WriteLine($"Studen {Name} with Id {Id},Gender {Gender} and Age {Age} from University with the Id {UniversityId}");
        }
    }
}
