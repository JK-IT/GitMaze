using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnSpot;

    private PlayerData pInfo;
    private GameManager gameManager;
    private GameObject player;
    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        pInfo = gameManager.GetpInfo();
        Debug.Log(this.name + " " + pInfo);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(mainCam.name);
        if (!pInfo)
        {
            Debug.LogError(this.name +  " Cannot find play info object");
            return;
        }

        player = Instantiate(pInfo.heroGameobjet, spawnSpot.transform.position, spawnSpot.transform.rotation) as GameObject;
        player.SetActive(true);
        player.name = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
