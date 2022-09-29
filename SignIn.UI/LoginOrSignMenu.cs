using Application.Services;
using SignIn.Domain.Enums;
using SignIn.Domain.Models;
using System;

namespace SignIn.UI
{

    public class LoginOrSignInMenu
    {
        public void LoginOrSignInMainMenu()
        {
            Console.Title = "Sign-in System";

            bool chooseExit = false;
            while (!chooseExit)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("Welcome, please select a option bellow:\n1-Log in\n2-Sign in\n3-Forget Password\n4-Exit");

                    int chooseMenu = int.Parse(Console.ReadLine());
                    eLoginOrSign option = (eLoginOrSign)chooseMenu;
                    switch (option)
                    {
                        case eLoginOrSign.Login:
                            Login();
                            break;
                        case eLoginOrSign.SignIn:
                            SignInMenu();
                            break;
                        case eLoginOrSign.ForgetPassword:
                            ForgetPassword();
                            break;
                        case eLoginOrSign.Exit:
                            chooseExit = true;
                            break;
                    }
                }catch
                {

                }
            }
        }
        public void SignInMenu()
        {
            Console.Clear();
            Console.WriteLine("Create account.");
            Console.WriteLine("Enter your email:");
            UserServices userServices = new UserServices();
            var email = Console.ReadLine();
            var emailExist = userServices.AlreadyRegistredEmail(email);

            if (emailExist)
            {
                Console.Clear();
                Console.WriteLine("Email already registred.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }

            var isValidEmail = userServices.IsValidEmail(email);

            if (!isValidEmail)
            {
                Console.Clear();
                Console.WriteLine("Invalid email entered.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }
            Console.Clear();
            Console.WriteLine("1-At least one lower case letter\r\n2-At least one upper case letter\r\n3-At least special character\r\n4-At least one number\r\n5-At least 8 characters length\n\nEnter a password:");
            string password = Console.ReadLine();
            var passwordValidator = userServices.ValidatePassword(password);

            if (!passwordValidator)
            {
                Console.Clear();
                Console.WriteLine("Weak password entered, try again.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }
            Console.Clear();
            Console.WriteLine("Confirm your password:");
            var confirmPassword = Console.ReadLine();
            if (confirmPassword != password)
            {
                Console.Clear();
                Console.WriteLine("Passwords do not match, try again.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }

            Console.Clear();
            Console.WriteLine("Enter your first name");
            string FirstName = Console.ReadLine();
            string Upper = FirstName;
            FirstName = userServices.GetFirstLetterUpper(Upper);
            Console.Clear();
            Console.WriteLine("Enter your last name");
            string LastName = Console.ReadLine();
            Upper = LastName;
            LastName = userServices.GetFirstLetterUpper(Upper);
            Console.Clear();
            Console.WriteLine("Please enter your SSN:\n1- Max: 8 characters\n2-No Special characters");
            string ssn = Console.ReadLine();

            bool validate = userServices.DataValidation(FirstName, LastName, ssn);
            if (!validate)
            {
                Console.Clear();
                Console.WriteLine("Incorrect data entered\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }

            Console.Clear();
            Console.WriteLine("Enter your birth year:\n1-Restrict to 13+ years");
            int birthyear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your birth month:");
            int birthmonth = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the day that you were born");
            int birthday = int.Parse(Console.ReadLine());
            var birthDateValidation = userServices.birthDateValidation(birthday, birthyear, birthmonth);

            if (!birthDateValidation)
            {
                Console.Clear();
                Console.WriteLine("Invalid birthdate entered.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }

            var birthDate = $"{birthyear}{birthmonth}{birthday}";
            var encryptPass = userServices.EncodePassword(password);
            Console.Clear();
            userServices.UserRegistry(FirstName, LastName, ssn, birthDate, encryptPass, email);
            Console.WriteLine("User registered successfully.\nPress enter to continue.");
            Console.ReadLine();
            LoginOrSignInMainMenu();

        }
        public void ForgetPassword()
        {

            Console.Clear();
            UserServices userServices = new UserServices();
            Console.WriteLine("Enter the informations to regain access to your account\nEmail:");
            var email = Console.ReadLine();
            var user = userServices.GetUserAccountInfo(email);
            if (user == null)
            {
                Console.WriteLine(""); Console.Clear();
                Console.WriteLine("Email not registred.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }
            Console.WriteLine("Enter your SSN:");
            var ssn = Console.ReadLine();
            if (ssn == null)
            {
                Console.WriteLine(""); Console.Clear();
                Console.WriteLine("SSN not found\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }
            Console.WriteLine("Enter your first name:");
            var firstname = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            var lastname = Console.ReadLine();
            Console.WriteLine("To confirm that you are not a bot enter the number of the currect month\nExample: Feb = 2\nApril = 4\nDecember = 12");
            int date = int.Parse(Console.ReadLine());
            var correctDate = DateTime.Now.Month;
            if (correctDate != date)
            {
                Console.WriteLine(""); Console.Clear();
                Console.WriteLine("Anti-bot answer incorrect.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }
            var validate = userServices.ValidatePerson(ssn, firstname, lastname, user);
            if (!validate)
            {
                Console.Clear();
                Console.WriteLine("Incorrect data entered, please revise your data and try again.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }
            string password = userServices.RandomPassword();
            Console.Clear();
            Console.WriteLine($"Your new password is: {password} please note.\nPress enter to return to main menu");
            var NewPassword = userServices.NewRandomPassword(password, user);
            Console.ReadLine();
            LoginOrSignInMainMenu();

        }
        private void Login()
        {
            UserServices userServices = new UserServices();
            Console.Clear();
            Console.WriteLine("Welcome, please enter your email:");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            if (email == ""||email == null||password == "" || password == null)
            {
                Console.Clear();
                Console.WriteLine("Invalid email or password.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }
            password = userServices.EncodePassword(password);
            User user = userServices.UserLogin(email);
            if (user == null||user.Password != password)
            {
                Console.Clear();
                Console.WriteLine("Incorrect email or password.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }
            if (user.ChangedPass == true)
            {
                ChangePassword(user);
            }
            LoggedMenu LogMenu = new LoggedMenu();
            LogMenu.LoggedUser(user);
        }
        public void ChangePassword(User user)
        {
            UserServices userServices = new UserServices();
            Console.WriteLine("1-At least one lower case letter\r\n2-At least one upper case letter\r\n3-At least special character\r\n4-At least one number\r\n5-At least 8 characters length\n\nEnter your new password:");
            string password = Console.ReadLine();
            var validate = userServices.ValidatePassword(password);
            if (!validate)
            {
                Console.Clear();
                Console.WriteLine("Invalid password.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }
            Console.WriteLine("Confirm your password:");
            string passwordConfirm = Console.ReadLine();
            if (password != passwordConfirm) 
            {
                Console.Clear();
                Console.WriteLine("Invalid password confirm.\nPress enter to return to main menu");
                Console.ReadLine();
                LoginOrSignInMainMenu();
            }
            userServices.RandomPasswordChangedMarkFalse(user);
            userServices.ChangePassword(password, user);
            Console.Clear();
            Console.WriteLine("Password changed\nPress enter to return to continue");
            Console.ReadLine();
            LoggedMenu LogMenu = new LoggedMenu();
            LogMenu.LoggedUser(user);

            
        }

    }
}
