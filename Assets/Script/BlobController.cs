using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlobController : SimpleController
{
    private Vector3 nextPos;
    public float distance = 10;
    private static System.Random r = new System.Random();
    private bool jump = false;
    private Animator anim;
    private Vector3 axes;
    private float wait;
    public int MAXSOUL = 2;
    



    // Start is called before the first frame update
    void Start()
    {   
        
        this.anim = GetComponent<Animator>();
        this.progress = new PlayerProgress();
        
        this.progress.soul = (int)Math.Floor(r.NextDouble() * MAXSOUL);
        this.progress.MAXLIFE = 5;
        this.progress.HITDAMAGE = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (!jump && wait < 0) {
            jump = true;
            anim.SetBool("jump", true);
            float angle = (float)r.NextDouble() *360;
            float x = (float)Math.Cos(angle) * distance;
            float y = (float)Math.Sin(angle) * distance;
            wait = (float)r.NextDouble() * 5;
            axes = new Vector3(x, y, 0);
            nextPos = axes + transform.localPosition;
            //this.GetComponent<BoxCollider2D>().enabled = false;
        }
        Vector3 vector = nextPos - transform.localPosition;
        Vector3 velocity = Vector3.zero;

        if (jump && Math.Abs(vector.x) + Math.Abs(vector.y) > 0.5f)
        {
            velocity = vector / (float)Math.Sqrt(Math.Pow(vector.x,2) + Math.Pow(vector.y,2)) ;
        }
        else
        {
            wait -= Time.deltaTime;
            anim.SetBool("jump", false);
            jump = false;
            //this.GetComponent<BoxCollider2D>().enabled = true;
        }
        GetComponent<Rigidbody2D>().velocity = velocity;

    }
}
