using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Array<TKey, TValue>
{
    public TKey Key;
    public TValue Value;
    public Array Next;

    public Array(TKey key, TValue value, Array next)
    {
        Key = key;
        Value = value;
        Next = next;
    }
}

