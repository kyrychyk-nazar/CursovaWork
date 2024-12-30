using System;
using System.Security.Cryptography;
using System.Text;

namespace CourseWork
{
    public class RegisterPlayer : ICommand
    {
        public IUserService userService { get; }

        public RegisterPlayer(IUserService userService)
        {
            this.userService = userService;
        }

        public void Execute()
        {
            bool ind = true;
            while (ind)
            {
                Console.WriteLine("Enter user name: ");
                string nameInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nameInput))
                {
                    Console.WriteLine("Name cannot be empty.");
                    continue;
                }

                var username = nameInput;
                
                Console.WriteLine("Enter password (minimum 8 characters): ");
                var passwdInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(passwdInput))
                {
                    Console.WriteLine("Password cannot be empty.");
                    continue;
                }

                if (passwdInput.Length < 8)
                {
                    Console.WriteLine("Password is too short, try again.");
                    continue;
                }
                
                var hashedPassword = HashPassword(passwdInput);
                
                Console.WriteLine("Choose account type (1-Standart, 2-Premium): ");
                var accountType = int.Parse(Console.ReadLine());
                if (accountType <= 2 && accountType > 0)
                {
                    userService.RegisterUser(username, hashedPassword, accountType);
                    Console.WriteLine($"Player {username} Created");
                    ind = false;
                }
                else
                {
                    Console.WriteLine("Invalid number entered, pick number from 1 to 3");
                }
            }
        }
        
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string GetInfo()
        {
            return "Register a new player";
        }
    }
}
