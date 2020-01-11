using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

using CodeMonkey.Utils;


public class playermove : MonoBehaviour {

    [SerializeField] float movespeed = 10f;
    [SerializeField] float jumpSpeed = 4f;
    [SerializeField] float revjumpSpeed = -4f;
    [SerializeField] float timeremain = 1f;
    [SerializeField] float flipscal;
    //[SerializeField] GameObject indicator;
    [SerializeField] feullimit fueled;
    //[SerializeField] private feullimit fuellimit;
    [SerializeField] GameObject partliceexplode;
    [SerializeField] string level;
    [SerializeField] float key = 0;
    //[SerializeField] feulupplate grav;

    public bool fuelup = true;
    public bool partspread = false;
    public bool isdead = false;
    public bool islosing = false;
    public LayerMask surfacetouch;
    public LayerMask bombtouch;
    public LayerMask startouch;
    public LayerMask up;
    public LayerMask norm;
    public LayerMask fup;
    public LayerMask flow;
    Rigidbody2D myRigidBody;
    
    BoxCollider2D feet;
    [SerializeField] float durationOfExplosion = 1f;

    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;

    Coroutine ResetCoroutine;
    //[SerializeField] AudioClip flightSound;
    //[SerializeField] [Range(0, 1)] float flightSoundVolume = 0.75f;
    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        feet = GetComponent<BoxCollider2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Jump();
        
        fuelLimit();

        if (islosing)
        {
            fueled.reducefeul();
        }

        hitwall();
        //gravity();
        //fuellimit.text = fuel.ToString();
        //Die();
        if (feet.IsTouchingLayers(fup))
        {
            fueled.feulingup();
        }else if (feet.IsTouchingLayers(flow))
        {
            fueled.losefeul();
        }

        flipplayer();
        
    }

    private void flipplayer()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        //Debug.Log(Mathf.Sign(myRigidBody.velocity.x)*transform.localScale.x);
        //flipscal = Mathf.Sign(myRigidBody.velocity.x) * transform.localScale.x;
        if (playerHasHorizontalSpeed)

        {

            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x) * flipscal, transform.localScale.y);

        }
    }

    private void fuelLimit()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            islosing = true;

            //AudioSource.PlayClipAtPoint(flightSound, Camera.main.transform.position, flightSoundVolume);
        }else if(Input.GetKeyUp(KeyCode.Space))
        {
            islosing = false;
        }        

    }

   

    private void Jump()
    {
        
        if (fueled.feuling() == true)
        {
            var deltaY = Input.GetAxis("Jump") * Time.deltaTime * jumpSpeed * .5f;
            myRigidBody.velocity += new Vector2(0f, deltaY);
            
        }

      
    }

    private void Move()
    {
        var PosX = Input.GetAxis("Horizontal") * movespeed * .2f;
      //  Debug.Log(Input.GetAxis("Horizontal"));
        myRigidBody.velocity = new Vector2(PosX, myRigidBody.velocity.y);

    }




    private void hitwall()
    {
        if (feet.IsTouchingLayers(surfacetouch))
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(partliceexplode, transform.position, transform.rotation);

            Destroy(explosion, durationOfExplosion);
            if(deathSound == null)
            {
                Debug.Log("no sound");
            }
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
            isdead = true;
            Die();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (feet.IsTouchingLayers(bombtouch))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject explosion = Instantiate(partliceexplode, transform.position, transform.rotation);

            Destroy(explosion, durationOfExplosion);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
            isdead = true;
            Die();
           
        }
        
    }

    public float getstar()
    {
        float star = key;
        return star;
    }

    private void Die()
    {
        
         if(isdead == true)
        {
           //timeremain -= Time.deltaTime;
           //if(timeremain <= 0)
           //{
                Debug.Log("reset");
                SceneManager.LoadScene(level);
                Physics2D.gravity = new Vector3(0, -8F, 0);
            //}
            // ResetCoroutine = StartCoroutine(resetContinuously());
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (feet.IsTouchingLayers(up))
        {
            
            Physics2D.gravity = new Vector3(0, 10.0f, 0);
            this.transform.Rotate(180f, 0, 0);
            jumpSpeed = revjumpSpeed;

        }
        else if (feet.IsTouchingLayers(norm))
        {
            Physics2D.gravity = new Vector3(0, -4.2f, 0);
            this.transform.Rotate(-180f, 0, 0);
            jumpSpeed = 10f;
        }

        if (feet.IsTouchingLayers(startouch))
        {
            Destroy(collision.gameObject);
            key += 1;
        }

    }
   
    //IEnumerator resetContinuously()
    //{
        
            //yield return new WaitForSeconds(0.1f);
        
    //}

}
