using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class feulupplate : MonoBehaviour {

    //public bool fuelup = true;
    //public bool fuellow = true;
    public bool bounce = true;
    public bool teleport = true;

    //public GameObject partlice;

    [SerializeField] float timestop;
    [SerializeField] feulupplate affectgav;
    //[SerializeField] TextMeshProUGUI timelimit;
    public float timeRemaining = 5;
    public float keiprt = 0f;
    public playermove player;
    //public feullimit feul;
    public GameObject moveplayer;
    public Transform teleportplace;
    BoxCollider2D platformcol;

    [SerializeField] AudioClip bounceSound;
    [SerializeField] [Range(0, 1)] float bounceSoundVolume = 0.75f;
    [SerializeField] AudioClip teleportSound;
    [SerializeField] [Range(0, 2)] float teleSoundVolume = 0.75f;
   
    //public float speed = 1.0f;
    //public Color startcolor;
    //public Color endcolor;
    //float starttime;

    void Start()
    {
        platformcol = GetComponent<BoxCollider2D>();
        //timelimit.text = timeRemaining.ToString();
        //starttime = Time.time;
    }

    public BoxCollider2D box()
    {
        return platformcol;
    }

    public float ftimer()
    {
        timeRemaining -= Time.deltaTime;
        return timeRemaining;
    }

    void Update()
    {
        /*float timemax = timeRemaining;
        timelimit.text = timeRemaining.ToString();
        if (timeRemaining <= 0)
        {
            timelimit.text = timestop.ToString();
            

        }
        else if (timeRemaining >= 0)
        {
            timemax = timeRemaining;
        }*/
    }
    
    /*public void furletime()
    {
        float timemax = timeRemaining;
        timelimit.text = timeRemaining.ToString();
        if (timeRemaining <= 0)
        {
            timelimit.text = timestop.ToString();


        }
        else if (timeRemaining >= 0)
        {
            timemax = timeRemaining;
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (teleport && keiprt <= player.getstar())
        {
            Debug.Log("portal is open");
            if (collision.gameObject.name.Equals("player"))
                {
                    
                    moveplayer.transform.position = teleportplace.transform.position;
                    AudioSource.PlayClipAtPoint(teleportSound, Camera.main.transform.position, teleSoundVolume);
                }
        
            
        }

        else if (bounce) {

            if (collision.gameObject.name.Equals("player"))
            {
                AudioSource.PlayClipAtPoint(bounceSound, Camera.main.transform.position, bounceSoundVolume);
                //float t = (Time.time - starttime) * speed;
                //GetComponent<SpriteRenderer>().material.color = Color.Lerp(startcolor, endcolor, t);
            }
            

        }
        
        
    }
}
