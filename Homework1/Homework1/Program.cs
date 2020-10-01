using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Person Maria = new Person("Maria", "F");
            Person Mihail = new Person("Mihail", "M");
            Maria.partner = Mihail;
            Mihail.partner = Maria;

            Person Sergey = new Person("Sergey", "M");
            Person Valentina = new Person("Valentina", "F");
            Sergey.partner = Valentina;
            Valentina.partner = Sergey;

            Person Sveta = new Person("Svetlana", "F", Maria, Mihail);
            Person Andrey = new Person("Andrey", "M", Sergey, Valentina, Sveta);
            Sveta.partner = Andrey;

            Person Alex = new Person("Alex", "F", Sveta, Andrey);

            Person Anton = new Person("Anton", "M", Sergey, Valentina);
            Person Nastia = new Person("Nastia", "F", Sergey, Valentina);

            Person Dima = new Person("Dima", "M");
            Dima.partner = Nastia;
            Person Misha = new Person("Misha", "M", Dima, Nastia);

            Maria.childrens.Add(Sveta);
            Mihail.childrens.Add(Sveta);
            Sveta.childrens.Add(Alex);
            Andrey.childrens.Add(Alex);
            Sergey.childrens.Add(Andrey);
            Sergey.childrens.Add(Anton);
            Sergey.childrens.Add(Nastia);
            Valentina.childrens.Add(Andrey);
            Valentina.childrens.Add(Anton);
            Valentina.childrens.Add(Nastia);
            Nastia.childrens.Add(Misha);
            Dima.childrens.Add(Misha);

            
            Console.WriteLine("Person:" + Alex.name);
            Alex.PrintParents();
            Console.WriteLine('\n');

            Console.WriteLine("Person:" + Maria.name);
            Maria.PrintParents();
            Console.WriteLine('\n');
            
            Console.WriteLine("Person:" + Alex.name);
            Alex.PrintUncle();            
            Alex.PrintCousin();
            Console.WriteLine('\n');

            Console.WriteLine("Person:" + Andrey.name);
            Andrey.PrintInLavs();
        }

    }
}
