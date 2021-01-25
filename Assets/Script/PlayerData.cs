using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  A Player Storage object for storing data
 */


[CreateAssetMenu(fileName ="player data" , menuName ="PlayerData")]
public class PlayerData : SingleObjectablePattern<PlayerData>
{
    public new string name = "kyle";
    public HeroTemplate hero;
}