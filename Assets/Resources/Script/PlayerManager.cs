using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnSpot;
    
    public List<ObjectData> objectdatalist;


    private KgameMan gameManager;
    private GameObject player;

    [System.Serializable]
    public struct ObjectData
    {
        public string tag;
        public GameObject model;
        public int amount;
    }


    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<KgameMan>();
        //Debug.Log(gameManager.GetDic().Count);
        player =  gameManager.GetDic()[PlayerPrefs.GetString("heroChoice")];
        player.name = "Player";
        player.transform.position = spawnSpot.transform.position;
        
        if(objectdatalist.Count != 0)
        {
            foreach(ObjectData obdata in objectdatalist)
            {
                Queue<GameObject> tempque = new Queue<GameObject>();
                for(int i = 0; i < obdata.amount; i++)
                {
                    GameObject tgo = Instantiate(obdata.model);
                    tgo.SetActive(false);
                    tgo.tag = obdata.tag;
                    tempque.Enqueue(tgo);
                }
                ObjectsPool.AddItem(obdata.tag, tempque);
            }
        }
        //ObjectsPool.ItemCheck(objectdatalist[0].tag);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(mainCam.name);
       player.SetActive(true);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
