using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class User
    {

        private int id;
        private String name;
        private String username;
        private String isAdmin;
        private String designation;

        public User(int id, string name, string username, string isAdmin, string designation)
        {
            Id = id;
            Name = name;
            Username = username;
            IsAdmin = isAdmin;
            Designation = designation;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Username { get => username; set => username = value; }
        public string IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string Designation { get => designation; set => designation = value; }
    }
}
