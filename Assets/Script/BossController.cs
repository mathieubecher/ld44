using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossController : SimpleController
{
    public GameObject target;
    private float speed = 1;
    private bool hit = false;
    private float hittime = 0;
    public float portee = 4;
    private Animator anim;
    private bool hitTarget = false;
    private float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.progress = new PlayerProgress();
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit && cooldown < 0.2) cooldown += Time.deltaTime;
        if (target != null)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            Vector3 vector = target.transform.localPosition - transform.localPosition;
            float distance = (float)Math.Sqrt(Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2));
            if (((distance < portee && target.transform.localPosition.y < transform.localPosition.y) || hit) && cooldown >= 0.2) HitTarget();
        }
        else
        {
            anim.SetBool("hit", false);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character")
        {   
            if(target == null   ) target = other.gameObject ; 
        }
    }
    void HitTarget()
    {
        if (!hit)
        {
            anim.SetBool("hit", true);
            hit = true;
            hitTarget = false;
        }
        hittime += Time.deltaTime;
        if(hittime > 2.2)
        {   
            hit = false;
            hittime = 0;
            anim.SetBool("hit", false);
            cooldown = 0;
        }
        if(hittime > 1 && hittime < 1.2)
        {
            Vector3 vector = target.transform.localPosition - transform.localPosition;
            float distance = (float)Math.Sqrt(Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2));
            if (distance < portee && target.transform.localPosition.y < transform.localPosition.y && !hitTarget)
            {
                
                LifeController life =  target.GetComponent(typeof(LifeController)) as LifeController;

                if (life.hit(transform.localPosition, 3))
                {
                    if(life.getLife()<=0)
                    {
                        LifeController mylife = GetComponent(typeof(LifeController)) as LifeController;
                        mylife.reset();
                    }
                    target = null;
                }
                hitTarget = true;
            }
        }
        
    }


    void Move(float distance, Vector3 vector)
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
