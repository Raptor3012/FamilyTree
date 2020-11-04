using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Numerics;

namespace Homework1
{
    partial class Person
    {
        private string Name;
        private Gender Gender;
        private Person[] Parents = new Person[2];
        private Person Partner;
        private HashSet<Person> Childrens = new HashSet<Person>();

        public Person(string name, Gender gender)
        {
            this.Name = name;
            this.Gender = gender;
        }

        public Person(string name, Gender gender, Person parent_1, Person parent_2)
        {
            this.Name = name;
            this.Gender = gender;
            this.SetParents(parent_1, parent_2);
            parent_1.SetChildren(this);
        }

        public Person(string name, Gender gender, Person parent_1, Person parent_2, Person partner)
        {
            this.Name = name;
            this.Gender = gender;
            this.SetParents(parent_1, parent_2);
            this.SetPartner(partner);
            parent_1.SetChildren(this);
        }

        public void SetParents(Person parent_1,Person parent_2)
        {
            if(this.Parents[0] == null & this.Parents[1] == null)
            {
                if (this != parent_1 & this != parent_2 & parent_1 != parent_2)
                {
                    this.Parents[0] = parent_1;
                    this.Parents[1] = parent_2;
                    parent_1.SetChildren(this);
                    
                }
            }            
        }

        public void SetChildren(Person children)
        {
            if (this != children & this.Parents[0] != children & this.Parents[1] != children)
            {
                this.Childrens.Add(children);
                if (this.Partner != null)
                {
                    this.Partner.Childrens.Add(children);
                }
            }
                
        }

        public void SetPartner(Person partner)
        {
            if(this != partner & partner.Partner == null & this.Partner == null)
            {
                this.Partner = partner;
                partner.Partner = this;
            }
                            
        }

        public string GetName()
        {
            String name = this.Name;
            return name;
        }

        public Person[] GetParents()
        {
            Person[] parents = new Person[2];
            parents[0] = this.Parents[0];
            parents[1] = this.Parents[1];
            return parents;
        }

        public HashSet<Person> GetUncles()
        {
            HashSet<Person> listUncles = new HashSet<Person>();
            foreach (Person parent in this.Parents)
            {
                if (parent == null) continue;
                foreach (Person ancestor in parent.Parents)
                {
                    if (ancestor == null) continue;
                    listUncles.UnionWith(ancestor.Childrens);
                }
            }
            listUncles.ExceptWith(this.Parents);
            HashSet<Person> listUnclesPartner = new HashSet<Person>();
            foreach (var uncle in listUncles)
            {
                if (uncle.Partner != null)
                    listUnclesPartner.Add(uncle.Partner);
            }
            listUncles.UnionWith(listUnclesPartner);
            return listUncles;
        }

        public HashSet<Person> GetCousins()
        {
            HashSet<Person> listCousins = new HashSet<Person>();
            foreach (Person parent in this.Parents)
            {
                if (parent == null) continue;
                foreach (Person ancestor in parent.Parents)
                {
                    if (ancestor == null) continue;
                    foreach (Person uncle in ancestor.Childrens)
                    {
                        if (uncle == null) continue;
                        listCousins.UnionWith(uncle.Childrens);
                    }
                    
                }
            }
            listCousins.Remove(this);
            return listCousins;
        }

        public Person[] GetInLavs()
        {
            if (this.Partner == null)
                return new Person[2];
            return this.Partner.GetParents();
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
    }
    enum Gender
    {
        Female,
        Male
    }
}
