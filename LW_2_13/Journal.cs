using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_13
{
    class Journal<T>
    {
        class JournalEntry<T>
        {
            public string CollectionName { get; private set; }
            public string EventDescription { get; private set; }
            public T Obj { get; private set; }
            public MyStack<T> CurrentCollection { get; private set; }

            public JournalEntry(MyStack<T> currentState, MyStackHandlerEventArgs<T> args)
            {
                CollectionName = args.Name;
                EventDescription = args.Description;
                Obj = args.Obj;
                currentState = currentState;
            }

            public override string ToString()
            {
                return $"{Obj.ToString()}:{EventDescription}:{CollectionName}";
            }
        }

        private List<JournalEntry<T>> _entries = new List<JournalEntry<T>>();

        public void Add(MyStack<T> currentState, MyStackHandlerEventArgs<T> args)
        {
            _entries.Add(new JournalEntry<T>(currentState, args));
        }

        public string Show()
        {
            string res = "";
            foreach (var entry in _entries)
            {
                res += entry.ToString();
            }
            return res;
        }

        // EVENT PART

        public void CollectionCountChanged(object sender, MyStackHandlerEventArgs<T> e)
        {
            Add(sender as MyStack<T>, e);
        }

        public void CollectionReferenceChanged(object sender, MyStackHandlerEventArgs<T> e)
        {
            Add(sender as MyStack<T>, e);
        }

        // END EVENT PART
    }        
}
