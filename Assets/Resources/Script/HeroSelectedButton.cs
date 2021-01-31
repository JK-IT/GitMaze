using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectedButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void onSelected()
    {
        Debug.Log(this.name + " : button click");
    }
}
