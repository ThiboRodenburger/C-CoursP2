using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MyDico<TKey, TValue> : IDico<TKey, TValue>
{
    

    public TValue this[TKey key] { get => Get(key); set => Set(key, value); }

    public void Add(TKey key, TValue value)
    {
        
    }

    public bool Contains(TKey key)
    {
        return true;
    }

    public TValue Get(TKey key)
    {
        
    }

    public void Set(TKey key, TValue value)
    {
        
    }
}

