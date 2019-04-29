using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killUnknow : MonoBehaviour
{
    public GameObject dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dialog d = dialog.GetComponent(typeof(Dialog)) as Dialog;
        if(d.i == d.dialog.Count)
        {
            LifeController lc = GetComponent(typeof(LifeController)) as LifeController;
            lc.hit(Vector3.zero, 5);
        }
    }
}
