using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnSpot;
    public FollowScript foScript;

    private PlayerData pInfo;
    private void Awake()
    {
        pInfo = Resources.FindObjectsOfTypeAll<PlayerData>()[0];
        //how u call method from other script
        foScript = GameObject.FindObjectOfType<FollowScript>();
        Debug.Log(foScript);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!pInfo)
        {
            Debug.LogError(this.name +  " Cannot find play info object");
        }

        GameObject player = Instantiate(pInfo.heroGameobjet, spawnSpot.transform.position, spawnSpot.transform.rotation) as GameObject;
        player.name = "Player";
        foScript.SetTarget(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
