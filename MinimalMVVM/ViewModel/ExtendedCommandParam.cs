using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MinimalMVVM.ViewModel
{
    public class ExtendedCommandParam : DependencyObject,IDictionary
    {
        public string Context { get; set; }
        public Dictionary<string, object> InternalDico { get; set; } = new Dictionary<string, object>();


        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public void Add(object key, object value)
        {
            if(value is ObjectProxy)
                InternalDico.Add((string)key, ((ObjectProxy)value).RefObject);
            else
                InternalDico.Add((string)key,value);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public object this[object key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ICollection Keys { get; }
        public ICollection Values { get; }
        public bool IsReadOnly { get; }
        public bool IsFixedSize { get; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public object SyncRoot { get; }
        public bool IsSynchronized { get; }
    }
}
