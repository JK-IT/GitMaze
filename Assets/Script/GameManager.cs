using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerData playerData;
    public static GameManager gmIns
    {
        get; private set;
    }

    protected GameManager() { }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void GmInit()
    {
        Debug.Log("gm init");
        var ins = FindObjectOfType<GameManager>();

        if(ins == null)
        {
            ins = new GameObject("Game Manager").AddComponent<GameManager>();
        }
        DontDestroyOnLoad(ins);
        gmIns = ins;
    }

    private void Awake()
    {
        playerData = Resources.FindObjectsOfTypeAll<PlayerData>()[0];
        Logpd();
    }


    public void NextScene()
    {
        int csi = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(csi + 1);
    }

    public void Logpd()
    {
        Debug.Log(gameObject.name + " " + playerData.name);
    }
}
