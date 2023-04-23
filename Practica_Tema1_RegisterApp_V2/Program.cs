using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica_Tema1_RegisterApp_V2
{
    class Program
    {
        public static List<Users>   listOfUsers;
        public static string        menu;
        public static int           countRetryLogin             = 3;
        public static int           countRetryChangePassword    = 3;
        static void Main(string[] args)
        {
            listOfUsers = new List<Users>();

            Console.WriteLine("Welcome to the application! Please write login / register / change password to continue");
            menu = Console.ReadLine();

            while (menu == "login" || menu == "register" || menu == "change password")
            {
                Console.WriteLine("you want to " + menu.ToString());

                if (menu == "register")
                {
                    Console.WriteLine("Please register first");
                    Console.WriteLine("Please, enter your username");
                    var username = Console.ReadLine();
                    Console.WriteLine("Please, enter your password");
                    var password = Console.ReadLine();

                    doRegister(username, password);
                }
                if (menu == "login")
                {
                    Console.WriteLine("Please, enter your username");
                    var username = Console.ReadLine();
                    Console.WriteLine("Please, enter your password");
                    var password = Console.ReadLine();

                    doLogin(username, password);
                }
                if (menu == "change password")
                {
                    Console.WriteLine("Please, enter your username");
                    var username = Console.ReadLine();
                    Console.WriteLine("Please, enter your current password");
                    var currentPassword = Console.ReadLine();
                    Console.WriteLine("Please, enter your new password");
                    var newPassword = Console.ReadLine();

                    changePassword(username, currentPassword, newPassword);
                }
                if (menu == "exit")
                {
                    break;
                }
            }
        }

        private static void doRegister(string _username, string _password)
        {
            //codul devine mai usor de citit daca inversezi logica din if-uri si creezi ceea ce se cheama GUARDS, adica
            // if string.IsNullOrWhiteSpace(_username) && string...(password) return;
            // if !isValidEmail Console.Write; return;
            // if !isValidPass Console.Write; return;
            // listOfUsers....
            
            if (_username != " " && _password != " ")
            {
                if (isValidEmail(_username))
                {
                    if (isValidPassword(_password))
                    {
                        listOfUsers.Add(new Users { username = _username, password = _password });
                        Console.WriteLine("You've successfully registered. Please type 'register', 'login', 'change password' or 'exit'");
                        menu = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Password must contain at least 10 characters and at least one number");
                    }
                }
                else
                {
                    Console.WriteLine("Email is not valid");
                }
            }
        }

        private static bool isValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        private static bool isValidPassword(string _password)
        {
            if (_password.Length >= 10 && _password.Any(char.IsDigit))
            {
                return true;
            }
            return false;
        }

        private static void doLogin(string _username, string _password)
        {
            int     index       = 0;
            bool    userFound   = false;

            // poti simplifica logica folosind LINQ
            // var user = listOfUsers.FirstOrDefault(u => u.userName == ... && u.pass == user.password);
            // apoi poti verifica daca user == null inseamna ca nu il ai, altfel poti face ceva
            while (index < listOfUsers.Count)
            {
                Users user = listOfUsers[index];

                if (user.blockedUser == false)
                {
                    if (_username == user.username && _password == user.password)
                    {
                        Console.WriteLine("Successfuly logged in! Please type 'register', 'login', 'change password' or 'exit'");
                        menu = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Password is not correct. Please retry!");

                        while (countRetryLogin > 0)
                        {
                            string passwordRetry = Console.ReadLine();

                            if (passwordRetry != user.password)
                            {
                                countRetryLogin--;// decrement after every wrong try
                                Console.WriteLine("Password is not correct. Please retry!");
                            }

                            if (passwordRetry == user.password)
                            {
                                userFound = true;
                                Console.WriteLine("Successfuly logged in! Please type 'register', 'login', 'change password' or 'exit'");
                                menu = Console.ReadLine();
                                break;
                            }
                        }
                        if (countRetryLogin == 0)
                        {
                            Console.WriteLine("Due to 3 wrong attempts, your user has been blocked");
                            user.blockedUser = true;
                            Console.WriteLine("Please type 'register', 'login', 'change password' or 'exit'");
                            menu = Console.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Your user is blocked. Please type 'register', 'login', 'change password' or 'exit'");
                    menu = Console.ReadLine();
                }

                if (userFound == true)
                {
                    break;
                }
                index++;
            }
        }

        private static void changePassword(string _username, string _currentPassword, string _newPassword)
        {
            int     index           = 0;
            bool    userFound       = false;
            bool    passwordChanged = false;
            
            while (index < listOfUsers.Count)
            {
                Users user = listOfUsers[index];

                if (user.blockedUser == false)
                {
                    if (_username == user.username && _currentPassword == user.password)
                    {
                        if (isValidPassword(_newPassword))
                        {
                            user.password = _newPassword;
                            passwordChanged = true;
                        }
                        else
                        {
                            Console.WriteLine("New password must contain at least 10 characters and at least one number.  Please type 'register', 'login', 'change password' or 'exit'");
                            menu = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your curent password is not correct. Please retry!");

                        while (countRetryChangePassword > 0)
                        {
                            string currentPasswordRetry = Console.ReadLine();

                            if (currentPasswordRetry != user.password)
                            {
                                Console.WriteLine("Your curent password is not correct. Please retry!");
                                countRetryChangePassword--;// decrement after every wrong try
                            }
                            //string newPasswordRetry = Console.ReadLine();

                            if (currentPasswordRetry == user.password && isValidPassword(_newPassword))
                            {
                                userFound = true;
                                Console.WriteLine("Password successfuly changed! Please type 'register', 'login', 'change password' or 'exit'");
                                menu = Console.ReadLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("New password must contain at least 10 characters and at least one number");
                            }

                        }
                        
                        if (countRetryChangePassword == 0)
                        {
                            Console.WriteLine("Due to 3 wrong attempts, your user has been blocked. Please type 'register', 'login', 'change password' or 'exit");
                            user.blockedUser = true;
                            menu = Console.ReadLine();
                        }
                        else if (userFound == true)
                        {
                            user.password = _newPassword;
                            passwordChanged = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("User doesn't exist. Please register");
                    menu = "register";
                }

                if(passwordChanged == true)
                {
                    Console.WriteLine("Password successfully changed. Please type 'register', 'login', 'change password' or 'exit'");
                    menu = Console.ReadLine();
                }
            }
        }
    }

    class Users
    {
        public string username { get; set;}
        public string password { get; set;}
        public bool blockedUser { get; set;}
    }
}
