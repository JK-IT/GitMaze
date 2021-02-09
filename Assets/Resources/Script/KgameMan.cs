using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


public class KgameMan : MonoBehaviour
{
    private LocalGameData localdat = null;

    string savedpath;

    private Thread bgthread;

    private static KgameMan _ins;

    public static KgameMan Intance
    {
        get { return _ins; } private set { }
    }

    protected KgameMan() { }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void GmInit()
    {
        Debug.Log("gm init " + Time.time);
    }

    private void Awake()
    {
        if(_ins != null && _ins != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _ins = this;
            DontDestroyOnLoad(_ins);
        }

        Debug.Log("Awake is called " + Time.time);

        savedpath = Path.Combine(Application.dataPath, "Resources/kgame.kd");
        bgthread = new Thread(StartupLoad);
        bgthread.Start();
        //LoadpDataRuntime();

    }

    private void Update()
    {
        // Debug.Log(localdat.pname);
    }

    private void OnApplicationPause(bool pause)
    {
        
    }

    private void OnApplicationQuit()
    {
        bgthread.Abort();
        SaveDat();
    }

    
    public void NextScene()
    {
        int csi = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(csi + 1);
    }

    public void GuestSignin()
    {
        if (bgthread.IsAlive)
        {
            bgthread.Join();
        }
        if(localdat.pname != "")
        {
            SceneManager.LoadScene("WaitingScene");
            return;
        }
        SceneManager.LoadScene("NameRegisterScene");
       
    }


    // look for p data at runtime and create one if not exist
    public void LoadPresetConf()
    {
        
    }

    public void SetpName()
    {
        //pInfoRuntime.username = PlayerPrefs.GetString("playername");
        localdat.pname = PlayerPrefs.GetString("playername");
        if (bgthread.IsAlive)
        {
            bgthread.Abort();
        }
        //bgthread = new Thread(SaveDat);
        //bgthread.Start();
    }

    // serialize file data
    public void SaveDat()
    {
        /* using binary to save data
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "kgame.kd");
        bf.Serialize(file, localdat);
        file.Close();
        */

        /* using json to save data */
        Debug.Log("Kgameman Saving data file')");
        File.WriteAllText(savedpath, JsonUtility.ToJson(localdat));
        Debug.Log("Kgameman DONE Saving data file')");
    }

    private void LoadDat()
    {
        /* load data with binary
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "kgame.kd", FileMode.Open);
        //StreamReader sr = new StreamReader(file);
        //string filecontent = sr.ReadToEnd();
        localdat = (LocalGameData)bf.Deserialize(file);
        file.Close();
        */

        // load data as json file
        Debug.Log("Kgameman Loading data file");
        if (File.Exists(savedpath))
        {
            localdat = JsonUtility.FromJson<LocalGameData>(File.ReadAllText(savedpath));
        }
        else
            localdat = null;

        Debug.Log("Kgameman DONE Loading data file");
    }

    private void StartupLoad()
    {
        if (!File.Exists(savedpath))
        {
            Debug.Log("Creating saved file ");
            localdat = new LocalGameData();
            File.WriteAllText(savedpath, JsonUtility.ToJson(localdat));
            Debug.Log("Done Creating saved file ");
        } else
        {
            Debug.Log("Saved File already exists");
            localdat = JsonUtility.FromJson<LocalGameData>(File.ReadAllText(savedpath));
        }
    }

}
