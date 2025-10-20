using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IDico <TKey, TValue>
{
    void Set(TKey key, TValue value);
    void Add(TKey key, TValue value);

    TValue Get(TKey key);

    bool Contains(TKey key);

    TValue this[TKey key] { get; set; }

}

