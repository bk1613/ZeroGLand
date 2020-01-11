using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfacedestroy : MonoBehaviour {

    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(collision.gameObject);
        Instantiate(deathVFX, transform.position, transform.rotation);

        //Destroy(explosion, durationOfExplosion);
    }
}
