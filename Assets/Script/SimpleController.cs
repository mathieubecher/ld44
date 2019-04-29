using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    public PlayerProgress progress;
    public GameObject soulPrefab;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
