using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class feullimit : MonoBehaviour {

    [SerializeField] Image feulbar;
    float maxfeul = 100;
    [SerializeField] float fuel;
    [SerializeField] feulupplate[] feultime;
    [SerializeField] TextMeshProUGUI[] timelimit;
    //[SerializeField] float[] timerfuel;
    public LayerMask player;
    [SerializeField] float timestop = 0;
    [SerializeField] timer[] feulti;
    public bool floating = true;
    //[SerializeField] TextMeshProUGUI timelimit;
    // Use this for initialization
    void Start () {
        feulbar = GetComponent<Image>();
        timelimit[0].text = feultime[0].ftimer().ToString();
        timelimit[1].text = feultime[1].ftimer().ToString();
        timelimit[2].text = feultime[2].ftimer().ToString();
        timelimit[3].text = feultime[3].ftimer().ToString();
    }

	void Update () {
        feulbar.fillAmount = fuel / maxfeul;

        if (fuel <= 0)
        {
            floating = false;
        }
        else
        {
            floating = true;
        }
        //timelimit.text = timeRemaining.ToString();
    }

    public bool feuling()
    {
        bool currentfeul = floating;
        return currentfeul;
    }

    public void reducefeul()
    {
            fuel -= (Time.deltaTime * 5f);
        
        //fuel -= 10f;
    }


    public void feulingup()
    {
        //timerfuel[0] -= Time.deltaTime;
        //timerfuel[1] -= Time.deltaTime;
        if (fuel < maxfeul)
        {
            
            
            //float ti1 = feultime[1].timer();

            if (feultime[0].box().IsTouchingLayers(player))
            {
                Debug.Log("platform1");
                float ti = feultime[0].ftimer();
                timelimit[0].text = ti.ToString();
                if (ti >= 0)
                {
                    fuel += (Time.deltaTime * 6f);
                }

                else if (ti <= 0)
                {
                    timelimit[0].text = timestop.ToString();
                }
            }

            
            else if (feultime[1].box().IsTouchingLayers(player))
            {
                Debug.Log("platform2");
                float ti = feultime[1].ftimer();
                timelimit[1].text = ti.ToString();
                if (ti >= 0)
                {
                    fuel += (Time.deltaTime * 6f);
                }

                else if (ti <= 0)
                {
                    timelimit[1].text = timestop.ToString();
                }
            }
            else if (feultime[2].box().IsTouchingLayers(player))
            {
                
                float ti = feultime[2].ftimer();
                timelimit[2].text = ti.ToString();
                if (ti >= 0)
                {
                    fuel += (Time.deltaTime * 6f);
                }

                else if (ti <= 0)
                {
                    timelimit[2].text = timestop.ToString();
                }
            }
            else if (feultime[3].box().IsTouchingLayers(player))
            {
                float ti = feultime[3].ftimer();
                timelimit[3].text = ti.ToString();
                if (ti >= 0)
                {
                    fuel += (Time.deltaTime * 6f);
                }

                else if (ti <= 0)
                {
                    timelimit[3].text = timestop.ToString();
                }
            }
            
        }
    }

    public void losefeul()
    {
        if (fuel < maxfeul)
        {
            fuel -= (Time.deltaTime * 2.0f);
        }
    }
}
