using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walsh_Lab2
{
    // Class Name : Pet
    // Class Vars : name, age, type
    // 
    class Pet
    {
        private string name;
        private int age;
        private string type;

        public Pet() { }

        public Pet(string inName, int inAge, string inType)
        {
            Name = inName;
            Age = inAge;
            Type = inType;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string DisplayPet() =>
            Name + " is " + Age + " year(s) old and a " + Type;
        

        
    }
}
