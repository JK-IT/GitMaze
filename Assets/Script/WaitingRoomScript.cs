using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRoomScript : MonoBehaviour
{
    [SerializeField]
    private Button sampleButt;
    [SerializeField]
    private GridLayoutGroup gridlay;

    Sprite charimg1, charimg2, charimg3;
    void Start()
    {
        //gridlay.constraintCount = 3;
        Sprite[] tk = Resources.LoadAll<Sprite>("CharacterImgs");
        Debug.Log(tk.Length);
        foreach( Sprite ti in tk)
        {
            Debug.Log(ti.name);
        }
        for ( int i = 0; i < tk.Length; i ++)
        {
            Button bui = Instantiate(sampleButt, gameObject.transform) as Button;
            bui.image.sprite = tk[i];
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
