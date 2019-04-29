using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress
{
    public int soul = 0;
    public int MAXLIFE = 0;
    public int HITDAMAGE = 1;

    


    public PlayerProgress()
    {

    }
    public void addForce()
    {
        if (soul > 0)
        {
            soul--;
            HITDAMAGE++;
        }
    }
    public void addLife()
    {
        if(soul > 0)
        {
            soul--;
            MAXLIFE++;
        }
    }
}
