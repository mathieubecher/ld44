using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnknowController : SimpleController
{
    public int MAXSOUL = 1;
    private Animator anim;
    
    // Start is called before the first frame update
    protected override void Start()    
    {
        this.anim = GetComponent<Animator>();
        this.progress = new PlayerProgress();
        this.progress.soul = MAXSOUL;
    }   

    // Update is called once per frame
    void Update()
    {
    }
}
