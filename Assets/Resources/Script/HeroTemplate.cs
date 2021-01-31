using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Character", menuName ="Character")]
public class HeroTemplate : ScriptableObject
{
    // Start is called before the first frame update
    public new string name;
    public Sprite HeroSprite;
    public GameObject goo;
}
