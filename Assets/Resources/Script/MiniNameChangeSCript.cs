using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/* 
 * this script will be attached to Input field
 * 
 */

public class MiniNameChangeSCript : MonoBehaviour
{
    private TMP_InputField inputField;
    private KgameMan gameman;

    private void Start()
    {
        inputField = gameObject.GetComponent<TMP_InputField>();
        gameman = GameObject.FindObjectOfType<KgameMan>();
        Debug.Log(this.name + " " + gameman);
    }

    // Start is called before the first frame update
    public void OnNameEditedEnd()
    {
        PlayerPrefs.SetString("playername", inputField.text);
        Debug.Log(inputField.text);

    }

    public void ToWaitingRoom()
    {
        gameman.SetpName();
        gameman.NextScene();
    }
}
