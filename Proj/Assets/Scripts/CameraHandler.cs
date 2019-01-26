using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private Vector3 firstOffset;
    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        firstOffset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 destination = player.transform.position + offset;
        float step = 3.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
    }

    public void ChangeDirection(CameraDirection direction, Vector3 portalPosition)
    {
        if (direction == CameraDirection.UP)
        {
            this.offset = firstOffset;
        }
        else if (direction == CameraDirection.DOWN)
        {
            this.offset = new Vector3(firstOffset.x, -firstOffset.y, firstOffset.z);
        }
        else if (direction == CameraDirection.RIGHT)
        {
            this.offset = new Vector3(firstOffset.y*1.2f, 0.0f, firstOffset.z);
        }
        else if (direction == CameraDirection.LEFT)
        {
            this.offset = new Vector3(-firstOffset.y*1.2f, 0.0f, firstOffset.z);
        }
    }
}
