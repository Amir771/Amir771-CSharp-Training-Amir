using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }
        public ProjectHelper Create(ProjectData project)
        {
            manager.Navigator.GoToManagePage();
            manager.Navigator.GoToManageProjectPage();

            InitNewProject();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }
        public ProjectHelper Remove()
        {
            manager.Navigator.GoToManagePage();
            manager.Navigator.GoToManageProjectPage();

            GoToEditProject();
            RemoveProject();
            return this;
        }
        public ProjectHelper InitNewProject()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }
        public ProjectHelper FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            Type(By.Id("project-description"), project.Description);
            return this;
        }
        public ProjectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            return this;
        }
        public ProjectHelper GoToEditProject()
        {
            driver.FindElement(By.CssSelector("td > a")).Click();
            return this;
        }
        public ProjectHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            return this;
        }
        public ProjectHelper CheckForProject()
        {
            manager.Navigator.GoToManagePage();
            manager.Navigator.GoToManageProjectPage();
            if (!IsElementPresent(By.CssSelector("td > a")))
            {
                ProjectData project = new ProjectData("Новая группа", "Групп не было");
                InitNewProject();
                FillProjectForm(project);
                SubmitProjectCreation();
            }
            return this;
        }
        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToManagePage();
            manager.Navigator.GoToManageProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//a[contains(@href, 'manage_proj_edit_page.php?project_id=')]"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text, element.Text));
            }

            return projects;
        }
    }
}
