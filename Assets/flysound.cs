using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flysound : MonoBehaviour {

    public AudioSource flight;

	// Use this for initialization
	void Start () {
        flight = GetComponent<AudioSource>();
        flight.Stop();
        
    }
	
	// Update is called once per frame
	void Update () {
        flightsound();
    }

    private void flightsound()
    {
        if (Input.GetButtonDown("Jump"))
        {
            flight.Play();
        }
        else if (Input.GetButtonUp("Jump"))
        {
            flight.Stop();

        }
    }
}
