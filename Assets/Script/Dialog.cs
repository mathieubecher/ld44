using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dialog : MonoBehaviour
{
    public List<String> dialog;
    public GameObject text;
    public GameObject background;
    public GameObject boite;
    private bool pressX = false;
    private bool show = true;
    public int i = 0;
    public GameObject player;
    private bool hitInput = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool ActionX()
    {
        if (hitInput) return false;
        else return (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.E));
    }
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.JoystickButton2) && !Input.GetKeyDown(KeyCode.E))
        {
            hitInput = false;
        }
        if (ActionX() && player != null)
        {
            hitInput = true;

            i++;
            if (i > dialog.Count) i= 0;
            if(i > 0) { 
                text.GetComponent<TextMesh>().text = dialog[i - 1 ].Replace(". ",".\n");
                
                Vector2 ret = new Vector2(text.GetComponent<TextMesh>().GetComponent<Renderer>().bounds.size.x, text.GetComponent<TextMesh>().GetComponent<Renderer>().bounds.size.y);
                background.transform.localScale = new Vector3(ret.x * 1.45f + 0.5f, ret.y*1.45f + 0.5f, 0);
            }


            
            //Debug.Log(transform.localPosition.x + " " + transform.localPosition.y + " " + " " +vector + " " +Math.Sqrt(Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2)));
            

        }

        if (player != null)
        {
            if ((GetComponent<CircleCollider2D>().Distance(player.GetComponent<BoxCollider2D>()).distance) > 0)
            {
                Debug.Log("sortie de la zone");
                player = null;
                i = 0;
            }
        }



        if (i == 0 || dialog[i-1]=="")
        {
            boite.SetActive(false);
        }
        else boite.SetActive(true);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name + " " + other.tag);
        if ((other.tag == "Character" || other.tag == "Ghost") && other.gameObject.name.Contains("player"))
        {
            player = other.gameObject;
        }
    }   
}
