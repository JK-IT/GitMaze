using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRoomScript : MonoBehaviour
{

    [SerializeField]
    private List<HeroTemplate> heroList;
    [SerializeField]
    private Button button;

    void Start()
    { 
        if(heroList.Count > 0)
        {
            for(int i = 0; i < heroList.Count; i++)
            {   
                SpawnHeroImg(heroList[i], i);
            }
        }
    }
    /*
     * @inher : HeroTemplate
     * @j: the order in hero list
     * */
    private void SpawnHeroImg(HeroTemplate inhero, int j)
    {
        Button b = Instantiate<Button>(button, transform);
        b.image.sprite = inhero.HeroSprite;
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
        PlayerData pd = Resources.FindObjectsOfTypeAll<PlayerData>()[0];
        pd.name = heroList[num].name;
        pd.hero = heroList[num];
    }

}
