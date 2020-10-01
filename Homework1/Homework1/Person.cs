using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Homework1
{
    partial class Person
    {
        public string name { get; }
        public string sex { get; }
        public Person parent_1 { set; get; }
        public Person parent_2 { set; get; }
        public Person partner { set; get; }
        public List<Person> childrens = new List<Person>();

        public Person(string name, string sex)
        {
            this.name = name;
            this.sex = sex;
        }
        public Person(string name, string sex,Person parent_1, Person parent_2)
        {
            this.name = name;
            this.sex = sex;
            this.parent_1 = parent_1;
            this.parent_2 = parent_2;
        }
        public Person(string name, string sex, Person parent_1, Person parent_2, Person partner)
        {
            this.name = name;
            this.sex = sex;
            this.parent_1 = parent_1;
            this.parent_2 = parent_2;
            this.partner = partner;
        }
        public void PrintParent(Person parent)
        {
            switch (parent.sex)
            {
                case "F":
                    Console.WriteLine("Mather: " + parent.name);
                    break;
                case "M":
                    Console.WriteLine("Father: " + parent.name);
                    break;
                default:
                    break;
            }
        }
        public void PrintParents()
        {
            if (this.parent_1 != null && this.parent_2 != null)
            {
                PrintParent(this.parent_1);
                PrintParent(this.parent_2);
            }
            else Console.WriteLine("No set parents"); 
        }
        public void PrintUncle()
        {
            Console.WriteLine("Uncle:");
            foreach (Person person in this.parent_2.parent_1.childrens)
            {
                if (person != this.parent_1 && person != this.parent_2)
                    Console.WriteLine(person.name);
            }
            foreach (Person person in this.parent_1.parent_1.childrens)
            {
                if (person != this.parent_1 && person != this.parent_2)
                    Console.WriteLine(person.name);
            }
        }
        public void PrintCousin()
        {
            Console.WriteLine("Cousin:");
            foreach (Person uncle in this.parent_2.parent_1.childrens)
            {
                if (uncle != this.parent_1 && uncle != this.parent_2)
                {
                    foreach(Person cousin in uncle.childrens)
                    {
                        Console.WriteLine(cousin.name);
                    }
                }
            }
            foreach (Person uncle in this.parent_1.parent_1.childrens)
            {
                if (uncle != this.parent_1 && uncle != this.parent_2)
                {
                    foreach (Person cousin in uncle.childrens)
                    {
                        Console.WriteLine(cousin.name);
                    }
                }
            }
        }
        public void PrintInLavs()
        {
            Console.WriteLine("In-laws:");
            Console.WriteLine(this.partner.parent_1.name);
            Console.WriteLine(this.partner.parent_2.name);
        }


    }
}
