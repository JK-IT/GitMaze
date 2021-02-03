using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class KgameMan : MonoBehaviour
{
    public PlayerData playerDat;
    public static KgameMan gmIns
    {
        get; private set;
    }

    protected KgameMan() { }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void GmInit()
    {
        Debug.Log("gm init");
        var ins = FindObjectOfType<KgameMan>();

        if (ins == null)
        {
            ins = new GameObject("Game Manager").AddComponent<KgameMan>();
        }
        DontDestroyOnLoad(ins);
        gmIns = ins;
    }

    private void Awake()
    {
        PlayerData ob = (PlayerData) AssetDatabase.LoadAssetAtPath("Assets/Resources/pInfo.asset", typeof(PlayerData));
        if(!ob)
        {
            PlayerData pinfo = PlayerData.Instance;
            AssetDatabase.CreateAsset(pinfo, "Assets/Resources/pInfo.asset");
        }
        playerDat = (PlayerData)AssetDatabase.LoadAssetAtPath("Assets/Resources/pInfo.asset", typeof(PlayerData));
        Logpd();
    }


    public void NextScene()
    {
        int csi = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(csi + 1);
    }

    public void PlayerRegisScene()
    {
        SceneManager.LoadScene("NameRegisterScene");
    }
    public void Logpd()
    {
        Debug.Log(gameObject.name + " " + playerDat.name);
    }
    public PlayerData GetpInfo()
    {
        return playerDat;
    }
}
