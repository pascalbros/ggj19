using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buca : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);
            var source = GetComponent<AudioSource>();
            source.PlayOneShot(source.clip);
        }
        else if(coll.gameObject.name == "MainCharacter")
        {
            GameObject.Find("deathHandler").GetComponent<deathHandler>().deathScreen();
        }
    }
}
