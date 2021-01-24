using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleObjectablePattern<T> : ScriptableObject where T : ScriptableObject
{
    static T _ins = null;
    public static T Instance
    {
        get
        {
            if (!_ins)
                _ins = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
            return _ins;
        }
    }
} 

