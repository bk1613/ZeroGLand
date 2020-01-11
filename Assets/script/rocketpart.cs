using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketpart : MonoBehaviour {

    public ParticleSystem fuelemit;
    public feullimit fuelsystem;
    private ParticleSystem.VelocityOverLifetimeModule velocityModule;
    // Use this for initialization
    void Start () {
        fuelemit = GetComponent<ParticleSystem>();
        fuelemit.Stop();
        fuelemit.Clear();
        velocityModule = fuelemit.velocityOverLifetime;
    }
	
	// Update is called once per frame
	void Update () {
        fueltank();
        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            velocityModule.xMultiplier = -2.5f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            velocityModule.xMultiplier = 2.5f;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            velocityModule.xMultiplier = 0f;
        }*/

    }
    private void fueltank()
    {
        if (fuelsystem.feuling() == true && Input.GetButtonDown("Jump"))
        {
           
                fuelemit.Play();
          }
           else if (Input.GetButtonUp("Jump") || fuelsystem.feuling() == false)
            {
               fuelemit.Stop();

            }
        
        
    }
}
