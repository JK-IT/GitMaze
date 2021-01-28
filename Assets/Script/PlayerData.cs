using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  A Player Storage object for storing data
 */


[CreateAssetMenu(fileName ="player data" , menuName ="PlayerData")]
public class PlayerData : SingleObjectablePattern<PlayerData>
{
    public new string name = "kyle";
    public GameObject heroGameobjet;
}
