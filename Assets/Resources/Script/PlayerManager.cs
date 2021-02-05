using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnSpot;

    private PlayerDataRuntime pRuntimeInfo;
    private KgameMan gameManager;
    private GameObject player;
    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<KgameMan>();
        pRuntimeInfo = gameManager.GetpRuntimeInfo();
        Debug.Log(this.name + " " + pRuntimeInfo);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(mainCam.name);
        if (!pRuntimeInfo)
        {
            Debug.LogError(this.name +  " Cannot find play info object");
            return;
        }

        player = Instantiate(pRuntimeInfo.heroGameobjet, spawnSpot.transform.position, spawnSpot.transform.rotation) as GameObject;
        player.SetActive(true);
        player.name = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
