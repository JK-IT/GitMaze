using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumbscript : MonoBehaviour
{
    // Start is called before the first frame update

    public float health = 200f;
    Animator animator;
    Animation anim;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator  fire()
    {
        while (true)
        {
            Debug.Log("fire fire");
            Vector2 bullpos = new Vector2(gameObject.transform.position.x + 1f, gameObject.transform.position.y);
            GameObject bull = ObjectsPool.GetObject("bullet");
            
            bull.transform.position = bullpos;
            bull.transform.localScale = gameObject.transform.localScale;
            bull.SetActive(true);
            bull.GetComponent<Rigidbody2D>().velocity = new Vector2(4f * gameObject.transform.localScale.x, 0);
            yield return new WaitForSeconds(2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //float p = collision.GetComponent<DamgePoints>().GetDamPoint();
        Destroy(collision.gameObject);
       // health -= p;

        if(health <= 0)
        {
            
            animator.SetTrigger("dietrigger");
            Destroy(gameObject, 0.45f);
        }
    }
}
