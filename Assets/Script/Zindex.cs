using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zindex : MonoBehaviour
{
    // Start is called before the first frame update
    private float z;
    void Start()
    {
        z = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z + transform.localPosition.y / 10000);
    }
}
