using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public InputActionAsset inInputAction;
    private InputActionMap playerActionMap;
    private InputAction movAction;
    private InputAction attkAction;

    private Vector2 movDir;
    private float movSpeed = 3f;

    private Rigidbody2D body;
    private BoxCollider2D coll;

    public GameObject inWeapon;

    bool isFiring = false;

    private float health = 200f;

    private Animator manAnimator;

    public List<GameObject> itemlist = new List<GameObject>();

    PlayerData playerinfo;

    private void Awake()
    {
        playerinfo = Resources.FindObjectsOfTypeAll<PlayerData>()[0];
        Debug.Log(gameObject.name + " " + playerinfo.name);
    }


    // Start is called before the first frame update
    void Start()
    {
        // set up INPUT
        if (inInputAction != null)
        {
            playerActionMap = inInputAction.FindActionMap("PlayerControlMap");
            playerActionMap.Enable();
            movAction = playerActionMap.FindAction("Move");
            attkAction = playerActionMap.FindAction("Fire");
            attkAction.performed += ctx => Fire(ctx);
            attkAction.canceled += ctx => Fire(ctx);

            playerActionMap.actionTriggered += contex => MyInputChangedHandle(contex);
        }
    }

    private void Fire(InputAction.CallbackContext ctx)
    {
        //Debug.Log(ctx.ReadValue<float>());
        if(!isFiring)
        {
            if(ctx.ReadValue<float>() == 1)
            {
                StartCoroutine(fireCou());
                isFiring = true;
            }
        }
       
    }

    IEnumerator fireCou()
    {

        if(inWeapon != null)
        {
            for(int i = 0; i < 2; i++)
            {
                Vector2 bullpos = new Vector2(gameObject.transform.position.x + (gameObject.transform.localScale.x * coll.bounds.size.x), gameObject.transform.position.y);
                GameObject bull = Instantiate(inWeapon, bullpos, Quaternion.identity) as GameObject;
                bull.transform.localScale = gameObject.transform.localScale;
                bull.GetComponent<Rigidbody2D>().velocity = new Vector2(4f * gameObject.transform.localScale.x, 0);
                yield return new WaitForSeconds(.3f);
            }
            isFiring = false;
        }
        
    }

    private void MyInputChangedHandle(InputAction.CallbackContext ctx)
    {
        if(ctx.action.name == "Move")
        {
            //Debug.Log(ctx.ReadValue<Vector2>());
            movDir = ctx.ReadValue<Vector2>();
            if(movDir.x != gameObject.transform.localScale.x)
            {
                if (movDir.x == 0) return;
                if( 0f < movDir.x && movDir.x <= 1f)
                {
                    gameObject.transform.localScale = new Vector3(1f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                } else
                {
                    gameObject.transform.localScale = new Vector3(-1f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                }
            }
        }
    }

    private void MoveChar()
    {
        body.velocity = movDir * movSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    private void FixedUpdate()
    {
        MoveChar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float p = collision.gameObject.GetComponent<DamgePoints>().GetDamPoint();
        Destroy(collision.gameObject);
        health -= p;
        if (health <= 0f)
        {
            playerActionMap.Disable();
            StartCoroutine(SpawnItem());
        }
    }
    IEnumerator SpawnItem()
    {
        //manAnimator.SetBool("diebool", true);
        yield return new WaitForSeconds(0.583f);
        if (itemlist.Count != 0)
        {
            Vector2 ipos = new Vector2(gameObject.transform.position.x + (gameObject.transform.localScale.x * coll.bounds.size.x + Random.Range(-0.2f, -0.2f)), gameObject.transform.position.y +Random.Range(-0.2f, 0.2f));
            Instantiate(itemlist[0], ipos, Quaternion.identity);

        }
        Destroy(gameObject);
    }
}
