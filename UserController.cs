using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhumlaKamnandi.BusinessLayer.Models;
using PhumlaKamnandi.DataLayer.Repositories;

namespace PhumlaKamnandi.BusinessLayer.Controllers
{
    // Handles user authentication, registration, and session management
    public class UserController
    {
        private UserRepository userRepo;          // Handles user data operations
        private static User currentUser;          // Stores currently logged-in user

        // Constructor initializes user repository
        public UserController()
        {
            userRepo = new UserRepository();
        }

        // Authenticates user credentials and creates session
        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception("Username and password are required");

            User user = userRepo.Authenticate(username, password);
            if (user == null)
                throw new Exception("Invalid username or password");

            currentUser = user;  // Set current user session
            return user;
        }

        // Registers a new user in the system
        public int Register(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.PasswordHash))
                throw new Exception("Username and password are required");

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
                throw new Exception("First name and last name are required");

            return userRepo.Create(user);
        }

        // Returns the currently logged-in user
        public static User GetCurrentUser()
        {
            return currentUser;
        }

        // Ends the current user session
        public void Logout()
        {
            currentUser = null;
        }

        // Checks if a user is currently logged in
        public static bool IsLoggedIn()
        {
            return currentUser != null;
        }
    }
}