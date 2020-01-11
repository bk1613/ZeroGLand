using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animshake : MonoBehaviour {

    public Animator camAnim;
	
    public void camshake()
    {
        camAnim.SetTrigger("shake");
    }
}
