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
            OnCollectionCountChanged(this, new MyStackHandlerEventArgs<T>(this.Name, "push", value));
            base.Push(value);
        }

        public new void Push(T[] values)
        {
            OnCollectionCountChanged(this, new MyStackHandlerEventArgs<T>(this.Name, "push many", values[0]));
            base.Push(values);
        }

        public new void Remove()
        {
            OnCollectionCountChanged(this, new MyStackHandlerEventArgs<T>(this.Name, "delete", this.Get()));
            base.Remove();
        }
        
        public new bool Remove(int index)
        {    
            if (_last != null)
            {
                Element<T>? deletedElement = _last;
                // go to deleting element
                for (int i = 0; i < index; i++)
                {
                    if (deletedElement != null)
                    {
                        deletedElement = deletedElement.PreviousElement;
                    }
                    else
                    {
                        return false;
                    }
                }
                // change connections
                deletedElement.NextElement.PreviousElement = deletedElement.PreviousElement;
                deletedElement.PreviousElement.NextElement = deletedElement.NextElement;

                T? value = deletedElement.Value;
                deletedElement.Dispose();

                OnCollectionCountChanged(this, new MyStackHandlerEventArgs<T>(this.Name, $"delete on position {index}", value));
                return true;
            }
            else
                return false;
        }

        public new void Dispose()
        {
            OnCollectionCountChanged(this, new MyStackHandlerEventArgs<T>(this.Name, "clear collection", this.Get()));
            base.Dispose();
        }

        public T this[int index]
        {
            get
            {
                if (index > 0 && index < this.Count)
                {
                    IEnumerator<T> en = this.GetEnumerator();
                    en.MoveNext();
                    for (int i = 0; i < index; i++)
                    {
                        en.MoveNext();
                    }
                    return en.Current;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < this.Count)
                {
                    var cur = this._last;
                    for (int i = 0; i < index; i++)
                    {
                        cur = cur.PreviousElement;
                    }
                    cur.Value = value;
                    OnCollectionReferenceChanged(this, new MyStackHandlerEventArgs<T>(this.Name, $"set new element in position {index}", value));
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Sort()
        {
            for (int i = 0; i < Count; i++)
            {
                Element<T> current = this._last;

                // go to beginning
                while (current.PreviousElement != null)
                    current = current.PreviousElement;

                for (int j = 0; j < Count - 1 - i; j++)
                {
                    if (current.Value is IComparable val && val.CompareTo(current.NextElement.Value) > 0)
                    {
                        Swap(current, current.NextElement);
                    }
                    current = current.NextElement;
                }
            }
        }

        private void Swap(Element<T> e1, Element<T> e2)
        {
            OnCollectionReferenceChanged(this, new MyStackHandlerEventArgs<T>(this.Name, "swap 1", e1.Value));
            OnCollectionReferenceChanged(this, new MyStackHandlerEventArgs<T>(this.Name, "swap 2", e2.Value));
            var tNext = e1.NextElement;
            var tPrev = e1.PreviousElement;
            e1.NextElement = e2.NextElement;
            e1.PreviousElement = e2.PreviousElement;
            e2.NextElement = tNext;
            e2.PreviousElement = tPrev;
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
