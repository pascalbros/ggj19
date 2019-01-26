using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fungoDeath : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "MainCharacter")
        {
            Destroy(coll.gameObject);
        }
    }
}
