using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayerController : LifeController
{
    
    public override void dead()
    {

        PlayerController pc = this.GetComponent(typeof(PlayerController)) as PlayerController;
        pc.Died();

        
    }
}
