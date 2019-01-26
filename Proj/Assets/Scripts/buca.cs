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
            Debug.Log(coll.gameObject.tag + " " + coll.gameObject.name);
            Destroy(coll.gameObject);
            if (coll.gameObject.FindGameObjectsWithTag("Player").Length == 0) Debug.Log("oh no");
            else Debug.Log(GameObject.FindGameObjectsWithTag("Player")[0].name);
        }
        else if(coll.gameObject.name == "MainCharacter")
        {
            Component mainChar = coll.gameObject.GetComponent<MainCharacter>();
            mainChar.transform.position = new Vector3(mainChar.transform.position.x, mainChar.transform.position.y + 1f, mainChar.transform.position.z); ;
        }
    }
}
