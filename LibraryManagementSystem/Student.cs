using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Student
    {

        private int student_id;
        private String student_name;
        private String gender;
        private String dob;
        private String dept;
        private String contactNum;

        public Student(int student_id, string student_name, string gender, string dob, string dept, string contactNum)
        {
            this.student_id = student_id;
            this.student_name = student_name;
            this.gender = gender;
            this.dob = dob;
            this.dept = dept;
            this.contactNum = contactNum;
        }

        public int Student_id { get => student_id; set => student_id = value; }
        public string Student_name { get => student_name; set => student_name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Dept { get => dept; set => dept = value; }
        public string ContactNum { get => contactNum; set => contactNum = value; }





        public override string ToString()
        {
            return "ID: " + student_id + " Name: " + student_name + " Gender: " + gender + " DOB: " + dob + " Department: " + dept;
        }

    }
}
