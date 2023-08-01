using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        private string name;
        private string description = "";
        public ProjectData()
        {
        }
        public ProjectData(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name; 
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Description.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + Name + " " + "в" + " " + "разработке" + " " + "публичный" + " " + Description;
        }
        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }
            else
            {
                return Description.CompareTo(other.Description);
            }
        }
        public string Id { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
    }
}
