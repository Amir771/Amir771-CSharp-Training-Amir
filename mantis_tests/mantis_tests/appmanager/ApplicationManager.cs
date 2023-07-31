﻿using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected ProjectHelper projectHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost/mantisbt-2.25.7";

            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            projectHelper = new ProjectHelper(this);
        }
        ~ApplicationManager() 
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToLoginPage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHelper Mail { get; set; }
        public LoginHelper Auth 
        { 
            get { return loginHelper; } 
        }
        public NavigationHelper Navigator 
        { 
            get { return navigator; } 
        }
        public ProjectHelper Project 
        { 
            get { return projectHelper; } 
        }
    }
}
