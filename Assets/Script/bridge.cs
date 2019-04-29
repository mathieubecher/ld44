using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge : MonoBehaviour
{
    private bool active = false;
    public GameObject wall;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " " + other.tag);
        if ((other.tag == "Character") && other.gameObject.name.Contains("player") && !active)
        {
            LifeController lc = other.gameObject.GetComponent(typeof(LifeController)) as LifeController;
            lc.dead();
            anim.SetBool("active", true);
            active = true;
            Destroy(wall);

        }
    }
}
