using System;

namespace LW_2_13
{
    class Program
    {
        static void Main(string[] args)
        {
            MyNewStack<Organization> stack1 = new MyNewStack<Organization>();            
            MyNewStack<Organization> stack2 = new MyNewStack<Organization>();
            stack1.Name = "Stack 1";
            stack2.Name = "Stack 2";

            Journal<Organization> journal1 = new Journal<Organization>();
            Journal<Organization> journal2 = new Journal<Organization>();

            stack1.CollectionCountChanged += journal1.CollectionCountChanged;
            stack1.CollectionReferenceChanged += journal1.CollectionReferenceChanged;

            stack1.CollectionReferenceChanged += journal2.CollectionReferenceChanged;
            stack2.CollectionReferenceChanged += journal2.CollectionReferenceChanged;

            Random rn = new Random();
            stack1.Push(new Organization(ref rn));
            stack1.Push(new Organization(ref rn));
            stack1.Push(new Factory(ref rn));
            stack1.Push(new Organization(ref rn));
            stack1.Push(new Library(ref rn));
            stack1.Push(new Organization(ref rn));

            stack2.Push(new Organization(ref rn));
            stack2.Push(new Organization(ref rn));

            stack1.Remove();

            stack2.Remove();

            stack1.Sort();

            stack2[0] = new Organization(ref rn);

            Console.WriteLine("Journal1");
            Console.WriteLine(journal1.Show());
            Console.WriteLine("Journal2");
            Console.WriteLine(journal2.Show());
        }
    }
}