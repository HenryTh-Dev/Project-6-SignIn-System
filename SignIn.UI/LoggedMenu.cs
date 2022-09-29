using SignIn.Domain.Enums;
using SignIn.Domain.Models;
using System;

namespace SignIn.UI
{
    public class LoggedMenu
    {
        public void LoggedUser(User user)
        {
            bool chooseExit = false;
            while (!chooseExit)
            {
                try
                {
                    Console.Clear();
                    LoginOrSignInMenu LoginMenu = new LoginOrSignInMenu();
                    Console.WriteLine("Welcome to the user menu.\n1-Show personal information\n2-Change Password\n3-Exit");

                    int chooseMenu = int.Parse(Console.ReadLine());
                    eLoggedMenu option = (eLoggedMenu)chooseMenu;
                    switch (option)
                    {
                        case eLoggedMenu.ShowData:
                            ShowPersonalData(user);
                            break;
                        case eLoggedMenu.ChangePassword:
                            LoginMenu.ChangePassword(user);
                            break;
                        case eLoggedMenu.Exit:
                            chooseExit = true;
                            break;
                    }
                }catch 
                {

                }
            }
        }
    private void ShowPersonalData(User user)
        {
            Console.Clear();
            Console.WriteLine($"First name: {user.Firstname}\nLast name: {user.Lastname}\nEmail:{user.Email}\nSSN:{user.Snn}\nBirthdate(YYYYMMDD): {user.Birthdate}");
            Console.ReadLine();
            
        }
    }
}
