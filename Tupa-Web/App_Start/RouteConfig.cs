﻿using System;
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
                "Error",
                "~/View/Error/Error.aspx");

            // Settings
            routes.MapPageRoute(
                "Settings",
                "Settings",
                "~/View/Configuracoes/Perfil.aspx");

            routes.MapPageRoute(
                "Perfil",
                "Perfil",
                "~/View/Configuracoes/Perfil.aspx");

            routes.MapPageRoute(
                "Account",
                "Account",
                "~/View/Configuracoes/Account.aspx");

            routes.MapPageRoute(
                "Themes",
                "Themes",
                "~/View/Configuracoes/Themes.aspx");

            routes.MapPageRoute(
                "Sessoes",
                "Sessoes",
                "~/View/Configuracoes/Sessoes.aspx");

            routes.MapPageRoute(
                "Plans",
                "Plans",
                "~/View/Configuracoes/Plans.aspx");

            routes.MapPageRoute(
                "Notifications",
                "Notifications",
                "~/View/Configuracoes/Notifications.aspx");

            routes.MapPageRoute(
                "Developer",
                "Developer",
                "~/View/Configuracoes/Developer.aspx");

            // Dashboard
            routes.MapPageRoute(
                "Dashboard",
                "Dashboard",
                "~/View/Dashboard/Dashboard.aspx");

            // Locate
            routes.MapPageRoute(
                "Locate",
                "Locate",
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
                "~/View/Register/Register.aspx");

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