using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public class KgameMan : MonoBehaviour
{
    public PlayerDataRuntime pInfoRuntime;
    private LocalGameData localdat = new LocalGameData();
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
        LoadpDataRuntime();
        if(PlayerPrefs.GetString("playername") == "")
        {
            //LoadDat();
            Debug.Log(PlayerPrefs.GetString("playername"));
        }

    }

    private void Update()
    {
       // Debug.Log(localdat.pname);
    }


    public void NextScene()
    {
        int csi = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(csi + 1);
    }

    public void GuestSignin()
    {
        if (PlayerPrefs.GetString("playername") == "")
            SceneManager.LoadScene("NameRegisterScene");
        else
            SceneManager.LoadScene("WaitingScene");
    }
    public void Logpd()
    {
        Debug.Log(gameObject.name + " " + pInfoRuntime.name);
    }
    public PlayerDataRuntime GetpRuntimeInfo()
    {
        return pInfoRuntime;
    }

    // look for p data at runtime and create one if not exist
    public void LoadpDataRuntime()
    {
        pInfoRuntime = (PlayerDataRuntime)AssetDatabase.LoadAssetAtPath("Assets/Resources/pInfo.asset", typeof(PlayerDataRuntime));
        if(!pInfoRuntime)
        {
            pInfoRuntime = PlayerDataRuntime.Instance;
            AssetDatabase.CreateAsset(pInfoRuntime, "Assets/Resources/pInfo.asset");
        }
    }

    public void SetpName(string inname)
    {
        PlayerPrefs.SetString("playername", inname);
        pInfoRuntime.username = inname;
        localdat.pname = inname;
        
    }

    // serialize file data
    public void SaveDat()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "kgame.kd");
        bf.Serialize(file, localdat);
        file.Close();
    }

    private void LoadDat()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "kgame.kd", FileMode.Open);
        //StreamReader sr = new StreamReader(file);
        //string filecontent = sr.ReadToEnd();
        localdat = (LocalGameData)bf.Deserialize(file);
        file.Close();
    }


}
