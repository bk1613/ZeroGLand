using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour {

    playermove player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<playermove>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 newcampos = new Vector2(player.transform.position.x + 16f, player.transform.position.y + 5f);
        transform.position = new Vector3(newcampos.x, newcampos.y, transform.position.z);
	}
}
