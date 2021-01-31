using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    private static GameObject target;
    private float speed = 8f;
    private Vector2 offset = new Vector2(1, 0);

    private void Awake()
    {
        //Debug.Log("Camera created");
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        LookatTarget();
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

    public void LookatTarget()
    {
        if(!GameObject.Find("Player"))
        {
            target = GameObject.Find("SpawnSpot");
        } else
        {
            target = GameObject.Find("Player");
        }
    }
}
