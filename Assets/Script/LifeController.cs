using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LifeController : MonoBehaviour
{

    public int LIFE = 3;
    private int life;
    private float time;
    private Vector3 axes = Vector3.zero;
    public float weight = 1;
    private PlayerProgress progress;

    // Start is called before the first frame update
    void Start()
    {
        this.life = LIFE;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(progress == null) { 
            SimpleController sc = this.GetComponent(typeof(SimpleController)) as SimpleController;
            if(sc.progress != null)
                this.progress = sc.progress;
            Debug.Log(progress.MAXLIFE);
        }

        if (time > 0 && weight > 0)
        {
            transform.localPosition += axes * time / (5 * weight);
            time -= Time.deltaTime;
            
        }
        
        if (progress != null && LIFE < progress.MAXLIFE)
        {
            Debug.Log(progress.MAXLIFE);
            LIFE = progress.MAXLIFE;
            life = LIFE;
            Debug.Log(life);
        }
    }
    public int getLife()
    {
        return life;
    }
    public void reset()
    {
        this.life = LIFE;
    }
    public bool hit(Vector3 origin, int damage = 1)
    {
        this.life -= damage;
        if (life <= 0) dead();

        time = 0.3f;
        
        axes = (transform.localPosition - origin) / (float)Math.Sqrt(Math.Pow((transform.localPosition - origin).x,2) + Math.Pow((transform.localPosition - origin).y, 2));
        axes.z = 0;
        return this.life <= 0;
        
    }
    public virtual void dead()
    {
        this.gameObject.SetActive(false);
        SimpleController controller = this.GetComponent(typeof(SimpleController)) as SimpleController;
        for (int i = 0; i < controller.progress.soul; i++)
        {
            Instantiate(controller.soulPrefab, transform.localPosition, Quaternion.identity);
        }   
        Destroy(this.gameObject);
    }
}
