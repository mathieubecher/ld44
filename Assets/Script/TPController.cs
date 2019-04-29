using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPController : MonoBehaviour
{
    public GameObject endtp;
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
            player.transform.localPosition = endtp.transform.localPosition;
        }
    }

}
