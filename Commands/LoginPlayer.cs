using System;
using System.Security.Cryptography;
using System.Text;

namespace CourseWork
{
    public class LoginPlayer : ICommand
    {
        public IUserService userService { get; }

        public LoginPlayer(IUserService userService)
        {
            this.userService = userService;
        }

        public void Execute()
        {
            bool ind = true;
            while (ind)
            {
                if (userService.LoggedInUserId != 0)
                {
                    Console.WriteLine("You need to logout first");
                    return;
                }

                Console.WriteLine("Enter your name: ");
                string nameInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nameInput))
                {
                    Console.WriteLine("Name cannot be empty.");
                    continue;
                }

                if (userService.GetRegisteredUser(nameInput) == null)
                {
                    Console.WriteLine($"User with name {nameInput} isn't registered yet");
                    return;
                }
                
                if (userService.GetRegisteredUser(nameInput).UserID == userService.LoggedInUserId)
                {
                    Console.WriteLine("You have been already logged in");
                    return;
                }

                var username = nameInput;
                
                Console.WriteLine("Enter your password: ");
                var passwdInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(passwdInput))
                {
                    Console.WriteLine("Password cannot be empty.");
                    continue;
                }

            
                var hashedPasswordInput = HashPassword(passwdInput);
                
                var registeredUser = userService.GetRegisteredUser(username);
                
                // Порівнюємо хешовані паролі
                if (!hashedPasswordInput.Equals(registeredUser.Password, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid password, try again");
                    continue;
                }
                
                userService.LoginUser(username, hashedPasswordInput);
                ind = false;
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
            return "Login by name and password";
        }
    }
}
