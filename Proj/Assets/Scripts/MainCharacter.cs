using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public static MainCharacter shared = null;
    public bool isGameActive = false;
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
        if (!this.isGameActive) { return; }
        this.UpdateRotation();
        this.UpdateMovement();
        //direction = this.GetDirection(GameObject.Find("Player").transform.position, transform.position);
    }

    void UpdateMovement()
    {
        Vector3 p = transform.position;
        Vector2 point = Utils.pointOnCircle(new Vector2(p.x, p.y), 1.0f, this.direction);
        var step = this.maxSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(point.x, point.y, -1), step);
    }

    void UpdateRotation()
    {
        float angle = 0.0f;
        if (this.direction >= 360 - 45 || this.direction < 45)
        {
            angle = 90.0f;
        }
        else if (this.direction >= 45 && this.direction < 135)
        {
            angle = 0.0f;
        }
        else if (this.direction >= 135 && this.direction < 225)
        {
            angle = 270.0f;
        }
        else
        {
            angle = 180.0f;
        }
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public static float GetDirection(Vector3 direction, Vector3 position)
    {
        Vector3 p = position;
        float angle = Mathf.Atan2(p.y - direction.y, p.x - direction.x) * 180 / Mathf.PI;
        return angle + 180;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.tag == "Portal")
        {
            CameraDirection dir = other.GetComponent<CameraPortal>().cameraDirection;
            Camera.main.GetComponent<CameraHandler>().ChangeDirection(dir, other.transform.position);
        }
    }
}