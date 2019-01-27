using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        first.SetActive(true);
        second.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.4)
        {
            first.SetActive(!first.activeSelf);
            second.SetActive(!second.activeSelf);
            timer = 0.0f;
        }
    }
}
