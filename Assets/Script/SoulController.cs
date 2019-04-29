using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoulController : MonoBehaviour
{
    public static System.Random r = new System.Random();
    private float distance = 10;
    private float time;
    private float TIMEPULSE =0.3f;
    private Vector3 axes = Vector3.zero;
    public GameObject sprite;
    private float timeDelete = 30;
    // Start is called before the first frame update
    void Start()
    {
        float angle = (float)r.NextDouble() * 360;
        float x = (float)Math.Cos(angle) * distance;
        float y = (float)Math.Sin(angle) * distance;
        axes = new Vector3(x, y);
        time = TIMEPULSE;
    }

    // Update is called once per frame
    void Update()
    {
        timeDelete -= Time.deltaTime;
        if (time > 0) { 
            time -= Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = axes *time;
            sprite.transform.localPosition += new Vector3(0, (time - TIMEPULSE / 2)/5);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        if (timeDelete < 0) Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Character" || other.tag == "Ghost") && !other.isTrigger)
        {
            SimpleController controller = other.gameObject.GetComponent(typeof(SimpleController)) as SimpleController;
            controller.progress.soul++; 
            Destroy(this.gameObject);
        }
    }
}
