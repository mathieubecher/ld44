using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarGestor : MonoBehaviour
{
    public MonoBehaviour character;
    public GameObject lifebar;
    public GameObject background;
    private float maxWidth;
    // Start is called before the first frame update
    void Start()
    {
        maxWidth = lifebar.transform.localScale.x;
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        LifeController pc = character.GetComponent(typeof(LifeController)) as LifeController;
        if (pc.LIFE > pc.getLife() && pc.getLife() > 0) show();
        else hide();    
        lifebar.transform.localScale = new Vector3((maxWidth / pc.LIFE)*pc.getLife(), lifebar.transform.localScale.y, lifebar.transform.localScale.z);
    }
    void show()
    {
        background.SetActive(true);
        lifebar.SetActive(true);
    }
    void hide()
    {
        background.SetActive(false);
        lifebar.SetActive(false);
    }
}
