using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRoomScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> heroGameObjList;
    [SerializeField]
    private Button button;

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
        b.onClick.AddListener(() => RegisterHero(j));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     *  This function will register the name and hero template to PlayerData: SingleScriptablePattern
     */
    public void RegisterHero(int num)
    {
        Debug.Log(this.name + " : button click");
        /*
        PlayerDatar pd = Resources.FindObjectsOfTypeAll<PlayerData>()[0];
        pd.name = heroGameObjList[num].name;
        pd.heroGameobjet = heroGameObjList[num];
        */
    }

}
