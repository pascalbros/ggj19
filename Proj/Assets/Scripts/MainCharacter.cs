using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public static MainCharacter shared = null;
    public bool isGameActive = false;
    public float maxSpeed = 3.0f;
    Animator animator;
    [Range(0, 359)]
    public float direction = 0.0f;
    private int directionEnum = 0;
    void Start()
    {
        MainCharacter.shared = this;
        this.animator = this.GetComponent<Animator>();
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
        int current = this.directionEnum;
        Debug.Log(current);
        if (this.direction >= 360 - 45 || this.direction < 45)
        {
            if (current != 1) {
                this.directionEnum = 1;
                animator.SetInteger("direction", 1);
            }
        }
        else if (this.direction >= 45 && this.direction < 135)
        {
            if (current != 2)
            {
                this.directionEnum = 2;
                animator.SetInteger("direction", 2);
            }
        }
        else if (this.direction >= 135 && this.direction < 225)
        {
            if (current != 3)
            {
                this.directionEnum = 3;
                animator.SetInteger("direction", 3);
            }
        }
        else
        {
            if (current != 4)
            {
                this.directionEnum = 4;
                animator.SetInteger("direction", 4);
            }
        }
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
        }else if (other.tag == "Malus")
        {
            Debug.Log("Malus!");
            GameObject.Find("deathHandler").GetComponent<deathHandler>().deathScreen();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.tag == "Malus" || collision.collider.tag == "Malus")
        {
            Debug.Log("Malus!");
            GameObject.Find("deathHandler").GetComponent<deathHandler>().deathScreen();
        }
    }
}