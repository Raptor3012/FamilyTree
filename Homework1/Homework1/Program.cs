using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Person Maria = new Person("Maria", Gender.Female);
            Person Mihail = new Person("Mihail", Gender.Male);
            //Maria.partner = Mihail;
            //Mihail.partner = Maria;

            Person Sergey = new Person("Sergey", Gender.Male);
            Person Valentina = new Person("Valentina", Gender.Female);
            //Sergey.partner = Valentina;
            //Valentina.partner = Sergey;

            Person Sveta = new Person("Svetlana", Gender.Female, Maria, Mihail);
            Person Andrey = new Person("Andrey", Gender.Male, Sergey, Valentina, Sveta);
            //Sveta.partner = Andrey;

            Person Alex = new Person("Alex", Gender.Female, Sveta, Andrey);

            Person Anton = new Person("Anton", Gender.Male, Sergey, Valentina);
            Person Nastia = new Person("Nastia", Gender.Female, Sergey, Valentina);

            Person Dima = new Person("Dima", Gender.Male);
            //Dima.partner = Nastia;
            Person Misha = new Person("Misha", Gender.Male, Dima, Nastia);

            Maria.Childrens.Add(Sveta);
            Mihail.Childrens.Add(Sveta);
            Sveta.Childrens.Add(Alex);
            Andrey.Childrens.Add(Alex);
            Sergey.Childrens.Add(Andrey);
            Sergey.Childrens.Add(Anton);
            Sergey.Childrens.Add(Nastia);
            Valentina.Childrens.Add(Andrey);
            Valentina.Childrens.Add(Anton);
            Valentina.Childrens.Add(Nastia);
            Nastia.Childrens.Add(Misha);
            Dima.Childrens.Add(Misha);
      
            
            Console.WriteLine("Person:" + Alex.Name);
            Alex.PrintParents();
            Console.WriteLine('\n');

            Console.WriteLine("Person:" + Maria.Name);
            Maria.PrintParents();
            Console.WriteLine('\n');

            Console.WriteLine("Person:" + Alex.Name);
            foreach(Person person in  Alex.GetUncles())
            {
                Console.WriteLine(person.Name);
            }
            //Alex.PrintCousin();
            Console.WriteLine('\n');

            //Console.WriteLine("Person:" + Andrey.name);
            //Andrey.PrintInLavs();
        }

    }
}
