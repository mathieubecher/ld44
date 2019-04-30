using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bridge : MonoBehaviour
{
    private bool active = false;
    public GameObject wall;
    private Animator anim;
    private bool bridgeKill = false;
    private float waitRespawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitRespawn > 0) waitRespawn -= Time.deltaTime;
        else if (bridgeKill)
        {
            anim.SetBool("active", true);
            active = true;
            Destroy(wall);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " " + other.tag);
        if ((other.tag == "Character") && other.gameObject.name.Contains("player") && !active)
        {
            PlayerController lc = other.gameObject.GetComponent(typeof(PlayerController)) as PlayerController;
            lc.RespawnBridge();
            
            waitRespawn = 2;
            bridgeKill = true;
            

        }
    }
}
