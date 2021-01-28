using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject target;
    private float speed = 8f;
    private Vector2 offset = new Vector2(1, 0);


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("SpawnSpot");   
    }

    // Update is called once per frame
    void Update()
    {
        if(!target)
        {
            target = GameObject.Find("SpawnSpot");
        }
    }
    private void FixedUpdate()
    {
        Vector3 endpos = target.transform.position;
        endpos.x += offset.x;
        endpos.y += offset.y;
        endpos.z = -8;


        Vector3 smoopos = Vector3.Lerp(transform.position, endpos, speed * Time.fixedDeltaTime);
        transform.position = smoopos;

        transform.LookAt(target.transform, Vector3.up);
    }

    public void SetTarget(GameObject intar)
    {
        Debug.Log("Setting target");
        target = intar;
    }
}
