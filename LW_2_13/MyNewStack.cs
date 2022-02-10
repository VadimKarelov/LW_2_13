using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_13
{
    internal class MyNewStack<T> : MyStack<T>
    {
        public string Name { get; set; } = "MyNewCollection";

        // EVENT PART

        public delegate void MyStackHandler(object sender, MyStackHandlerEventArgs<T> args);

        public event MyStackHandler CollectionCountChanged;

        public event MyStackHandler CollectionReferenceChanged;

        public virtual void OnCollectionReferenceChanged(object sender, MyStackHandlerEventArgs<T> args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(sender, args);
        }

        public virtual void OnCollectionCountChanged(object sender, MyStackHandlerEventArgs<T> args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(sender, args);
        }

        // END EVENT PART

        public new void Push(T value)
        {
            OnCollectionCountChanged(this, new MyStackHandlerEventArgs<T>(this.Name, "add", value));
            base.Push(value);
        }

        public new void Remove()
        {
            OnCollectionCountChanged(this, new MyStackHandlerEventArgs<T>(this.Name, "delete", this.Get()));
            base.Remove();
        }        
    }

    class MyStackHandlerEventArgs<T> : EventArgs
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public T Obj { get; set; }

        public MyStackHandlerEventArgs(string name, string description, T obj)
        {
            Name = name;
            Description = description;
            Obj = obj;
        }
    }
}
