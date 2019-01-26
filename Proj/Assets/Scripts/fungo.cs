using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fungo : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "MainCharacter")
        {
            Vector3 pos1 = this.transform.position;
            Vector3 pos2 = MainCharacter.shared.transform.position;
            float direction = MainCharacter.GetDirection(pos1, pos2);
            MainCharacter.shared.direction = direction;
        }
    }
}
