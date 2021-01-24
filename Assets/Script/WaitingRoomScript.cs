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
            foreach (HeroTemplate hero in heroList)
            {
                SpawnHeroImg(hero);
            }
        }
    }

    private void SpawnHeroImg(HeroTemplate inhero)
    {
         Button b = Instantiate<Button>(button, transform);
         b.image.sprite = inhero.HeroSprite;
         b.onClick.AddListener( RegisterImages);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterImages()
    {
        Debug.Log(this.name + " : button click");
        PlayerData pd = Resources.FindObjectsOfTypeAll<PlayerData>()[0];
        pd.kname = "keristy";
        Debug.Log(pd.kname);
    }

}
