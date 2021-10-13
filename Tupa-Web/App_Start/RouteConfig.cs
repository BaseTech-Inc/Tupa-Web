using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tupa_Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Home
            routes.MapPageRoute(
                "Default",
                "",
                "~/View/Home/Home.aspx");

            // Error
            routes.MapPageRoute(
                "Error",
                "Error/{codStatus}/{*queryvalues}",
                "~/View/Error/Error.aspx",
                false,
                new RouteValueDictionary{ { "codStatus", "([1-9]){3}" } });

            // Settings
            routes.MapPageRoute(
                "Settings",
                "Settings",
                "~/View/Configuracoes/Perfil.aspx");

            routes.MapPageRoute(
                "Settings_Perfil",
                "Settings/Perfil",
                "~/View/Configuracoes/Perfil.aspx");

            routes.MapPageRoute(
                "Settings_Themes",
                "Settings/Themes",
                "~/View/Configuracoes/Themes.aspx");

            routes.MapPageRoute(
                "Settings_Plans",
                "Settings/Plans",
                "~/View/Configuracoes/Plans.aspx");

            routes.MapPageRoute(
                "Settings_Notifications",
                "Settings/Notifications",
                "~/View/Configuracoes/Notifications.aspx");

            // About
            routes.MapPageRoute(
                "About",
                "About",
                "~/View/About/About.aspx");

            // Dashboard
            routes.MapPageRoute(
                "Dashboard",
                "Dashboard/{interval}",
                "~/View/Dashboard/Dashboard.aspx");

            // Locate
            routes.MapPageRoute(
                "Locate",
                "Locate/{pageNumber}",
                "~/View/Locais/Locais.aspx");

            // Login
            routes.MapPageRoute(
                "Login",
                "Login",
                "~/View/Login/Login.aspx");

            routes.MapPageRoute(
                "Login_Verify",
                "Login/Verfiy",
                "~/View/Login/Login__Verify.aspx");

            routes.MapPageRoute(
                "Login_Reset-Password",
                "Login/Reset-Password",
                "~/View/Login/Login__ResetPassword.aspx");

            routes.MapPageRoute(
                "Login_GeneratePasswordReset",
                "Login/GeneratePasswordReset",
                "~/View/Login/Login__GeneratePasswordReset.aspx");

            // Map
            routes.MapPageRoute(
                "Map",
                "Map",
                "~/View/Mapa/Mapa.aspx");

            // Privacy
            routes.MapPageRoute(
                "Privacy",
                "Privacy",
                "~/View/Privacy/Privacy.aspx");

            // Terms
            routes.MapPageRoute(
                "Terms",
                "Terms",
                "~/View/Terms/Terms.aspx");

            // Register
            routes.MapPageRoute(
                "Register",
                "Register",
                "~/View/Register/Register.aspx",
                false);

            routes.MapPageRoute(
                "Register_Plan",
                "Register/Plan",
                "~/View/Register/Register__Plan.aspx");

            routes.MapPageRoute(
                "Register_Verify",
                "Register/Verify",
                "~/View/Register/Register__Verify.aspx");
        }
    }
}