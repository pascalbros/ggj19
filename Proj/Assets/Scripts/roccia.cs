using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roccia : MonoBehaviour
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
        if (coll.gameObject.name == "MainCharacter")
        {
            Debug.Log("ciao");
            GameObject.Find("deathHandler").GetComponent<deathHandler>().deathScreen();
        }
    }
}
