using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForce : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name + " " + other.tag);
        if ((other.tag == "Character") && other.gameObject.name.Contains("player"))
        {
            player = other.gameObject;
            SimpleController sc = other.gameObject.GetComponent(typeof(SimpleController)) as SimpleController;
            sc.progress.addForce();
        }
    }
}
