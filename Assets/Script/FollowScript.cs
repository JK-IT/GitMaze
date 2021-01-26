using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    GameObject player;
    private float speed = 8f;
    private Vector2 offset = new Vector2(1, 0);


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 endpos = player.transform.position;
        endpos.x += offset.x;
        endpos.y += offset.y;
        endpos.z = -8;


        Vector3 smoopos = Vector3.Lerp(transform.position, endpos, speed * Time.fixedDeltaTime);
        transform.position = smoopos;

        transform.LookAt(player.transform, Vector3.up);
    }
}
