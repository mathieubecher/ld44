using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerGhostController : SimpleController
{
    private Animator anim;
    public float speed = 1;
    public GameObject player;
    public GameObject spawner;
    public bool hitInput = true;

    public GameObject UIDead;

    public GameObject life;
    public GameObject strength;
    public GameObject soul;

    public Text lifeUI;
    public Text strengthUI;
    public Text soulUI;
    // Start is called before the first frame update
    protected override void Start()
    {
        hitInput = true;
        this.anim = GetComponent<Animator>();
        if(progress == null) progress = new PlayerProgress();
    }

    // Update is called once per frame
    protected override void Update()
    {
        UpdateUI();
        if ((!Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.JoystickButton1))) hitInput = false; 
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector3(movex * speed, movey * speed);

        anim.SetBool("moveBottom", movey < 0 && Math.Abs(movey) > 0.1f);
        anim.SetBool("moveTop", movey > 0 && Math.Abs(movey) > 0.1f);
        anim.SetBool("moveLeft", movex < 0 && Math.Abs(movex) > 0.1f);
        anim.SetBool("moveRight", movex > 0 && Math.Abs(movex) > 0.1f);
        anim.SetBool("move", Math.Abs(movex) > 0.5f || Math.Abs(movey) > 0.1f);


        if (ActionB() && progress.soul > 0)
            Respawn();
    }

    public bool ActionB()
    {
        if (hitInput) return false;
        else return (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1));
    }
    


    void Respawn()
    {
        progress.soul--;
        this.gameObject.SetActive(false);
        GameObject playerClone = Instantiate(player, new Vector3(transform.localPosition.x, transform.localPosition.y, 0), Quaternion.identity);

        PlayerController pc = playerClone.GetComponent(typeof(PlayerController)) as PlayerController;
        pc.progress = progress;
        pc.spawner = spawner;
        pc.UIDead = UIDead;
        pc.lifeUI = lifeUI;
        pc.soulUI = soulUI;
        pc.strengthUI = strengthUI;
        Destroy(this.gameObject);
    }
    public void UpdateUI()
    {
        strengthUI.text = progress.HITDAMAGE + "";
        lifeUI.text = progress.MAXLIFE + "";
        soulUI.text = progress.soul + "";
    }

}
