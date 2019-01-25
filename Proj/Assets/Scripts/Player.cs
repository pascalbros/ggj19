using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("P1 Horizontal"), Input.GetAxis("P1 Vertical"), 0);
        this.transform.position += move * speed * Time.deltaTime;
    }
}
