using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hitbox : MonoBehaviour
{
    public bool delete = true;
    private float t;
    public int force = 1;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 0.3 && delete) Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character" && !other.isTrigger) {
            LifeController lc = other.gameObject.GetComponent(typeof(LifeController)) as LifeController;
            if(lc != null)
            lc.hit(transform.parent.gameObject.transform.localPosition,force);
        }
    }
}
