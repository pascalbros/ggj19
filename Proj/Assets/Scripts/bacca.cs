using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacca : MonoBehaviour
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
            coll.gameObject.GetComponent<Player>().bacca = -1;
            Destroy(this.gameObject);
        }
    }
}
