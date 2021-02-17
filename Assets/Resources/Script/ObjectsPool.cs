using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectsPool 
{

    public static Dictionary<string, Queue<GameObject>> poolContainer = new Dictionary<string, Queue<GameObject>>();


    public static void ItemCheck(string tag) { 
        if(poolContainer.ContainsKey(tag))
        {
            Debug.Log("re u logging')");
            Debug.Log(poolContainer[tag].Count);
        }
    }

    public static void AddItem(string tag, Queue<GameObject> obque) 
    {
        Debug.Log("adding item to objects pools");
        poolContainer.Add(tag, obque);    
    }

    public static GameObject GetObject(string tag)
    {
        if(!poolContainer.ContainsKey(tag))
        {
            Debug.Log("Key not exists");
            Debug.Log(poolContainer[tag].Count);
            return null;
        } else
        {
            return poolContainer[tag].Dequeue();
        }
    }
    public static void PutAwayObject(string tag, GameObject inobj)
    {
        if (!poolContainer.ContainsKey(tag))
        {
            return;
        }
        else
        {
            Debug.Log("enque object");
            poolContainer[tag].Enqueue(inobj);
            inobj.SetActive(false);
        }
    }
}
