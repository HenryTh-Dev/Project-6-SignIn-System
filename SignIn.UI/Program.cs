using SignIn.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using SignIn.Infra.Context;

namespace SignIn.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            LoginOrSignInMenu menu = new LoginOrSignInMenu();
            menu.LoginOrSignInMainMenu();
            
        }
    }
}
