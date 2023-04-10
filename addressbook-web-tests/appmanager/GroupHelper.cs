using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{

    public class GroupHelper : HelperBase
    {
        
         public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper RemoveGroup(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper ModifyGroup(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModify();
            FillGroupForm(newData);
            SubmitGroupModify();
            ReturnToGroupsPage();
            return this;
        }

        
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index+1) + "]/input")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

       public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModify()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper InitGroupModify()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public bool GroupFound()
        {
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.Name("selected[]"));
        }

        private List<GroupData> groupCashe = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCashe == null)
            {
                groupCashe = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCashe.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupCashe);        
        }
    }
}
