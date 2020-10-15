﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Numerics;

namespace Homework1
{
    partial class Person
    {
        public string Name { get; }
        public Gender Gender { get; }
        public Person[] Parents = new Person[2];
        public Person Partner { get; }
        public List<Person> Childrens = new List<Person>();

        public Person(string name, Gender gender)
        {
            this.Name = name;
            this.Gender = gender;
        }

        public Person(string name, Gender gender, Person parent_1, Person parent_2)
        {
            this.Name = name;
            this.Gender = gender;
            this.Parents[0] = parent_1;
            this.Parents[1] = parent_2;
        }

        public Person(string name, Gender gender, Person parent_1, Person parent_2, Person partner)
        {
            this.Name = name;
            this.Gender = gender;
            this.Parents[0] = parent_1;
            this.Parents[1] = parent_2;
            this.Partner = partner;
        }

        public void SetChildren(Person children)
        {
            this.Childrens.Add(children);
        }

        public void PrintParents()
        {
            if (this.Parents[0] != null || this.Parents[1] != null)
            {
                foreach (Person parent in this.Parents)
                {
                    switch (parent.Gender)
                    {
                        case Gender.Female:
                            Console.WriteLine("Mather: " + parent.Name);
                            break;
                        case Gender.Male:
                            Console.WriteLine("Father: " + parent.Name);
                            break;
                        default:
                            break;
                    }
                }
            }
            else { Console.WriteLine("Not Set Parents"); }    
        }

        public Person[] GetParents()
        {        
            return Parents;            
        }
       
        public HashSet<Person> GetUncles()
        {
            HashSet<Person> Temp = new HashSet<Person>();
            foreach (Person parent in this.Parents)
            {
                foreach(Person ancestor in parent.Parents)
                {
                    Temp.UnionWith(ancestor.Childrens);
                }
            }
            Temp.ExceptWith(this.Parents);
            return Temp;
        }


        //public void PrintCousin()
        //{
        //    Console.WriteLine("Cousin:");
        //    foreach (Person uncle in this.parent_2.parent_1.childrens)
        //    {
        //        if (uncle != this.parent_1 && uncle != this.parent_2)
        //        {
        //            foreach(Person cousin in uncle.childrens)
        //            {
        //                Console.WriteLine(cousin.name);
        //            }
        //        }
        //    }
        //    foreach (Person uncle in this.parent_1.parent_1.childrens)
        //    {
        //        if (uncle != this.parent_1 && uncle != this.parent_2)
        //        {
        //            foreach (Person cousin in uncle.childrens)
        //            {
        //                Console.WriteLine(cousin.name);
        //            }
        //        }
        //    }
        //}
        //public void PrintInLavs()
        //{
        //    Console.WriteLine("In-laws:");
        //    Console.WriteLine(this.partner.parent_1.name);
        //    Console.WriteLine(this.partner.parent_2.name);
        //}

        


    }
    enum Gender
    {
        Female,
        Male
    }
}
