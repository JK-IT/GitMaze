using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaitingRoomScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> heroGameObjList;
    [SerializeField]
    private Button button;
    private KgameMan gaman;
    

    void Awake()
    {
        gaman = GameObject.FindObjectOfType<KgameMan>();
        TMP_Text title = GameObject.Find("Title").GetComponent<TMP_Text>();
        title.text += (PlayerPrefs.GetString("playername") + "!!!");
    }

    void Start()
    { 
        if(heroGameObjList.Count > 0)
        {
            for(int i = 0; i < heroGameObjList.Count; i++)
            {   
                SpawnHeroImg(heroGameObjList[i], i);
            }
        }
    }
    /*
     * @inher : HeroTemplate
     * @j: the order in hero list
     * */
    private void SpawnHeroImg(GameObject inhero, int j)
    {
        Button b = Instantiate<Button>(button, transform);
        b.image.sprite =  inhero.GetComponent<SpriteRenderer>().sprite; //inhero.HeroSprite;
        b.name = inhero.name;
        b.onClick.AddListener(() => RegisterHero(b.name));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     *  This function will register the name and hero template to PlayerData: SingleScriptablePattern
     */
    public void RegisterHero(string charname)
    {
        Debug.Log(this.name + " : button click");
        PlayerPrefs.SetString("heroChoice", charname); //this will be used to load from array or resources
    }

    public void StartGame()
    {
        gaman.NextScene();
    }

}
