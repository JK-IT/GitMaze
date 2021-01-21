using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRoomScript : MonoBehaviour
{
    [SerializeField]
    private Button sampleButt;
   
    [SerializeField]
    private List<HeroTemplate> heroList; 

    Sprite charimg1, charimg2, charimg3;
    void Start()
    {
        heroList = new List<HeroTemplate>();
        
        
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
