using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnSpot;

    private KgameMan gameManager;
    private GameObject player;
    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<KgameMan>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(mainCam.name);
       
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
