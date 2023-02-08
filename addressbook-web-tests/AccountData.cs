using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    internal class AccountData
    {
        private string username;
        private string passwword;

        public AccountData(string username, string passwword)
        {
            this.username = username;
            this.passwword = passwword;
        }
        
        public string Username
        {
            get
            { 
                return username; 
            }
            set
            {
                username = value;
            }

        }

        public string Password
        {
            get
            { 
                return passwword;
            }
            set
            { 
                passwword = value; 
            }
        }
    }
}
