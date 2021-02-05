using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  A Player Storage object for storing data
 */


[CreateAssetMenu(fileName ="player data" , menuName ="PlayerDataRuntime")]
public class PlayerDataRuntime : SingleObjectablePattern<PlayerDataRuntime>
{
    public string username = "username";
    public string email = "";
    public GameObject heroGameobjet;

}
