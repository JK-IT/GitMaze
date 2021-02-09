using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A custom class that will behave as storage and singleton 
 * Which will give you consistent information across the game
 * SCRIPTABLE OBJECT ONLY GOOD FOR SAVING DEFAULT VALUE FROM DEVELOPMENT , BEFORE THE BUILD
 * IT IS NOT GOOD TO SAVE CHANGES DURING RUNTIME, CUZ WHEN GAME RESTART THE CHANGES MADE TO THME
 * WILL BE LOST
 */
public abstract class SingleObjectablePattern<T> : ScriptableObject where T : ScriptableObject
{
    static T _ins = null;

    public static T Instance
    {
        get
        {
            if (!_ins)
                _ins = ScriptableObject.CreateInstance<T>();
                //_ins = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
            return _ins;
        }
    }
} 

