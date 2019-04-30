using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using System.Threading;

public enum Direction
{
    TOP, LEFT, BOTTOM, RIGHT
}

public class PlayerController : SimpleController
{
    private Animator anim;
    public float speed = 1;
    public bool hit = false;
    private float hitingtime = 0;
    public float hitingtimemax = 0.5f;
    private Direction direction;
    public GameObject spawner;
    private bool died = false;

    public GameObject ghost;
    public GameObject life;
    public GameObject strength;
    public GameObject soul;


    public GameObject hitleft;
    public GameObject hitright;
    public GameObject hitbottom;
    public GameObject hittop;
    public bool hitInput = true;

    public GameObject UIDead;

    public Text lifeUI;
    public Text strengthUI;
    public Text soulUI;
    private bool bridgeKill = false;
    private float waitRespawn = 0;
    // Start is called before the first frame update
    protected override void Start()
    {
        this.anim = GetComponent<Animator>();
        direction = Direction.BOTTOM;
        hitInput = true;
        if (progress == null)
        {
            progress = new PlayerProgress();
            progress.MAXLIFE = 3;
        }

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (waitRespawn > 0) waitRespawn -= Time.deltaTime;
        if (!died && !(hit && hitingtime < hitingtimemax)) { 
            UpdateUI();
            float movex = Input.GetAxis("Horizontal");
            float movey = Input.GetAxis("Vertical");
            
            hit = false;
            hitingtime = 0;

            if (ActionB() && !hit && !hitInput) { 
                Hit();
                hitInput = true;
            }

            else if ((!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.JoystickButton1))) hitInput = false;

            float vector = 1;

            GetComponent<Rigidbody2D>().velocity = new Vector3(movex*speed*vector, movey * speed * vector);
      

            anim.SetBool("moveBottom", movey < 0 && Math.Abs(movey) > 0.1f);
            anim.SetBool("moveTop", movey > 0 && Math.Abs(movey) > 0.1f);
            anim.SetBool("moveLeft", movex < 0 && Math.Abs(movex) > 0.1f);
            anim.SetBool("moveRight", movex > 0 && Math.Abs(movex) > 0.1f);
            anim.SetBool("move", Math.Abs(movex) > 0.5f || Math.Abs(movey) > 0.1f);
            if (anim.GetBool("moveBottom") && !anim.GetBool("moveTop") && !anim.GetBool("moveRight") && !anim.GetBool("moveLeft")) direction = Direction.BOTTOM;
            else if (!anim.GetBool("moveBottom") && anim.GetBool("moveTop") && !anim.GetBool("moveRight") && !anim.GetBool("moveLeft")) direction = Direction.TOP;
            else if (!anim.GetBool("moveBottom") && !anim.GetBool("moveTop") && anim.GetBool("moveRight") && !anim.GetBool("moveLeft")) direction = Direction.RIGHT;
            else if (!anim.GetBool("moveBottom") && !anim.GetBool("moveTop") && !anim.GetBool("moveRight") && anim.GetBool("moveLeft")) direction = Direction.LEFT;


            anim.SetBool("hit",hit);
        }
        else if(hit && hitingtime < hitingtimemax)
        {
            hitingtime += Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        else if(died && !bridgeKill)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                GameObject ghostClone = Instantiate(ghost, this.spawner.transform.localPosition, Quaternion.identity);
                PlayerGhostController gc = ghostClone.GetComponent(typeof(PlayerGhostController)) as PlayerGhostController;
                gc.progress = progress;
                gc.spawner = spawner;
                gc.UIDead = UIDead;
                gc.UIDead.SetActive(false);
                gc.lifeUI = lifeUI;
                gc.strengthUI = strengthUI;
                gc.soulUI = soulUI;

                Destroy(this.gameObject);
            }
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        else if(waitRespawn <= 0)
        {
            GameObject ghostClone = Instantiate(ghost, this.transform.localPosition, Quaternion.identity);
            PlayerGhostController gc = ghostClone.GetComponent(typeof(PlayerGhostController)) as PlayerGhostController;
            gc.progress = progress;
            gc.spawner = spawner;
            gc.UIDead = UIDead;
            gc.UIDead.SetActive(false);
            gc.lifeUI = lifeUI;
            gc.strengthUI = strengthUI;
            gc.soulUI = soulUI;

            Destroy(this.gameObject);
        }
    }
    void Hit()
    {
        hit = true;
        if (direction == Direction.TOP)
        {
            GameObject hitbox = Instantiate(hittop, transform);
            System.Random r = new System.Random();
            hitbox.transform.localPosition += new Vector3((float)r.NextDouble() * 0.0001f, (float)r.NextDouble() * 0.0001f, (float)r.NextDouble() * 0.0001f);
            Hitbox hc = hitbox.GetComponent(typeof(Hitbox)) as Hitbox;
            hc.force = progress.HITDAMAGE;
        }
        else if (direction == Direction.BOTTOM)
        {
            GameObject hitbox = Instantiate(hitbottom, transform);
            System.Random r = new System.Random();
            hitbox.transform.localPosition += new Vector3((float)r.NextDouble() * 0.0001f, (float)r.NextDouble() * 0.0001f, (float)r.NextDouble() * 0.0001f);
            Hitbox hc = hitbox.GetComponent(typeof(Hitbox)) as Hitbox;
            hc.force = progress.HITDAMAGE;
        }
        else if (direction == Direction.LEFT)
        {
            GameObject hitbox = Instantiate(hitleft, transform);
            System.Random r = new System.Random();
            hitbox.transform.localPosition += new Vector3((float)r.NextDouble() * 0.0001f, (float)r.NextDouble() * 0.0001f, (float)r.NextDouble() * 0.0001f);
            Hitbox hc = hitbox.GetComponent(typeof(Hitbox)) as Hitbox;
            hc.force = progress.HITDAMAGE;
        }
        else if (direction == Direction.RIGHT)
        {
            GameObject hitbox = Instantiate(hitright, transform);
            System.Random r = new System.Random();
            hitbox.transform.localPosition += new Vector3((float)r.NextDouble() * 0.001f, (float)r.NextDouble() * 0.0001f, (float)r.NextDouble() * 0.0001f);
            Hitbox hc = hitbox.GetComponent(typeof(Hitbox)) as Hitbox;
            hc.force = progress.HITDAMAGE;
        }
        

    }
    public bool ActionB()
    {
        if (hitInput) return false;
        else return (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1));
    }
    public void Died() {
        UIDead.SetActive(true);
        died = true;
        anim.SetBool("died", true);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }
    public void RespawnBridge()
    {
        died = true;
        anim.SetBool("died", true);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        waitRespawn = 2;
        bridgeKill = true;
        
    }
    public void UpdateUI()
    {
        strengthUI.text = progress.HITDAMAGE + "";
        lifeUI.text = progress.MAXLIFE + "";
        soulUI.text = progress.soul + "";
    }

}
