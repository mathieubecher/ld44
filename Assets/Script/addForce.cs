using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class addForce : MonoBehaviour
{
    private GameObject player;
    private bool hitInput = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
            SimpleController sc = player.GetComponent(typeof(SimpleController)) as SimpleController;
            sc.progress.addForce();
        }
        if (player != null)
        {
            if ((GetComponent<CircleCollider2D>().Distance(player.GetComponent<BoxCollider2D>()).distance) > 0)
            {
                Debug.Log("sortie de la zone");
                player = null;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name + " " + other.tag);
        if ((other.tag == "Character") && other.gameObject.name.Contains("player"))
        {
            player = other.gameObject;

        }
    }
}
