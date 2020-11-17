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
            Maria.SetPartner(Mihail);

            Person Sergey = new Person("Sergey", Gender.Male);
            Person Valentina = new Person("Valentina", Gender.Female);
            Sergey.SetPartner(Valentina);

            Person Sveta = new Person("Svetlana", Gender.Female, Maria, Mihail);
            Person Andrey = new Person("Andrey", Gender.Male, Sergey, Valentina, Sveta);

            Person Alex = new Person("Alex", Gender.Female, Sveta, Andrey);

            Person Anton = new Person("Anton", Gender.Male, Sergey, Valentina);
            Person Nastia = new Person("Nastia", Gender.Female, Sergey, Valentina);

            Person Dima = new Person("Dima", Gender.Male);
            Dima.SetPartner(Nastia);
            Person Misha = new Person("Misha", Gender.Male, Dima, Nastia);
          
            Console.WriteLine("Person:" + Alex.GetName());
            Alex.PrintParents();
            Console.WriteLine('\n');

            Console.WriteLine("Person:" + Maria.GetName());
            Maria.PrintParents();
            Console.WriteLine('\n');

            //Проверка GetUncles()
            Console.WriteLine("Person:" + Alex.GetName());
            foreach(Person person in  Alex.GetUncles())
            {
                Console.WriteLine(person.GetName());
            }
            //Alex.PrintCousin();
            Console.WriteLine('\n');

            //Проверка GetCousins()
            Console.WriteLine("Person:" + Alex.GetName());
            foreach (Person person in Alex.GetCousins())
            {
                Console.WriteLine(person.GetName());
            }
            Console.WriteLine('\n');

            //Проверка GetInLavs()
            Console.WriteLine("Person:" + Andrey.GetName());
            foreach (Person person in Andrey.GetInLavs())
            {
                Console.WriteLine(person.GetName());
            }

            Person Dimaaaa = new Person("Dima", Gender.Male);
            Dimaaaa.GetCousins();
            Dimaaaa.GetParents();
            Dimaaaa.GetUncles();
            Dimaaaa.GetInLavs();

            Person Alex_1 = new Person("Alex_1 ", Gender.Male);

            Person Sergey_1 = new Person("Sergey_1", Gender.Male);
            Person Valentina_1 = new Person("Valentina_1", Gender.Female);

            Alex_1.SetChildren(Sergey_1);
            Alex_1.SetChildren(Valentina_1);

            Person Sergey_2 = new Person("Sergey_2", Gender.Male);
            Person Valentina_2 = new Person("Valentina_2", Gender.Female);
            Valentina_2.SetPartner(Sergey_2);
            Sergey_1.SetChildren(Sergey_2);

            Alex_1.SetParents(Sergey_2, Valentina_2);

            Alex.SetChildren(Sergey);
        }

    }
}
