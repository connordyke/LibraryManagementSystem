using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public static class CurrentUser
    {

        private static int id;
        private static String name;
        private static String username;
        private static String isAdmin;
        private static String designation;

        public static int Id { get => id; set => id = value; }
        public static string Name { get => name; set => name = value; }
        public static string Username { get => username; set => username = value; }
        public static string IsAdmin { get => isAdmin; set => isAdmin = value; }
        public static string Designation { get => designation; set => designation = value; }
    }
}
