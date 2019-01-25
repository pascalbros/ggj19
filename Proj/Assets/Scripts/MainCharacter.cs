﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    static MainCharacter shared = null;

    public float maxSpeed = 3.0f;

    [Range(0, 359)]
    public float direction = 0.0f;
    void Start()
    {
        MainCharacter.shared = this;
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateRotation();
    }

    void UpdateRotation()
    {
        float angle = 0.0f;
        if (this.direction >= 360 - 45 || this.direction < 45)
        {
            angle = 0.0f;
        }
        else if (this.direction >= 45 && this.direction < 135)
        {
            angle = 90.0f;
        }
        else if (this.direction >= 135 && this.direction < 225)
        {
            angle = 180.0f;
        }
        else
        {
            angle = 270.0f;
        }
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}