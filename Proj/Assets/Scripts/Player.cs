using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("P1 Horizontal"), Input.GetAxis("P1 Vertical"), 0);
        this.transform.position += move * speed * Time.deltaTime;
        HandleCallButton();
    }

    private void HandleCallButton()
    {
        bool input = Input.GetButton("P1 Call");
        if (!input) { return; }
        Vector3 pos1 = this.transform.position;
        Vector3 pos2 = MainCharacter.shared.transform.position;
        float direction = MainCharacter.GetDirection(pos1, pos2);
        MainCharacter.shared.direction = direction;
    }

    private float constraintAngle(float angle)
    {
        float result = angle - 90;
        if (result < 0)
        {
            result = 360 - Mathf.Abs(result);
        }
        return result;
    }
}
