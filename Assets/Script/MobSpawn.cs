using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    public List<GameObject> objects;
    public GameObject spawnObject;
    public int max = 10;
    public Vector3 maxdistance;
    private static System.Random r = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> allcontent = objects;
        for (int i = 0; i < allcontent.Count; i++)
        {
            
            if (allcontent[i] == null)
            {
                objects.Remove(allcontent[i]);
            }
            
        }
        while(objects.Count < max)
        {
            Vector3 v = new Vector3((float)r.NextDouble() * maxdistance.x, (float)r.NextDouble() * maxdistance.y);
            GameObject o = Instantiate(spawnObject, new Vector3(transform.localPosition.x, transform.localPosition.y, 0) + v, Quaternion.identity);
            objects.Add(o);
        }
    }
}
