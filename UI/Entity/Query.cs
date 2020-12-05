using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Query
    {
        private static EduContext db = new EduContext();



        public static List<Admin> AdminList()
        {
            return db.Admins.ToList();
        }

        public static List<Branch> BranchList()
        {
            return db.Branches.ToList();
        }

        public static List<Contract> ContractList()
        {
            return db.Contracts.ToList();
        }

        public static List<Customer> CustomerList()
        {
            return db.Customers.ToList();
        }

        public static List<Education> EducationList()
        {
            return db.Educations.ToList();
        }




        public static List<Lesson> LessonList()
        {
            return db.Lessons.ToList();
        }

        public static List<Payment> PaymentList()
        {
            return db.Payments.ToList();
        }

        public static List<Student> StudentList()
        {
            return db.Students.ToList();
        }


        public static List<Teacher> TeacherList()
        {
            return db.Teachers.ToList();
        }

        public static List<User> UserList()
        {
            return db.Users.ToList();
        }

        public static List<Category> CategoryList()
        {
            return db.Categories.ToList();
        }

        public static List<Unit> UnitList()
        {
            return db.Units.ToList();
        }

        public static int EducationCount()
        {
            return db.Educations.Count();
        }
        public static int LessonCount()
        {
            return db.Lessons.Count();
        }
        public static int TeacherCount()
        {
            return db.Teachers.Count();
        }
        

    }
}
