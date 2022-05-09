using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{

    private float yaw;
    private float pitch;


    [Tooltip("Mouse sensitivity")]
    public float sensitivity;
    [Tooltip("Player to follow")]
    public GameObject player;


    // Use this for initialization
    void Start()
    {
        Menu.ShowMouse(false);
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Menu.IsOnPause())
        {
            MoveCamera();
        }
    }

    /// <summary>
    /// Move the player's camera with the corresponding movement of the user's mouse
    /// </summary>
    void MoveCamera()
    {
        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch -= sensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Min(70f, pitch);
        pitch = Mathf.Max(-70f, pitch);
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.position = player.transform.position + new Vector3(0, 0.75f, 0);
        player.transform.eulerAngles = new Vector3(0, yaw, 0);

    }

    /// <summary>
    /// Change the camera's rotation
    /// </summary>
    /// <param name="v"></param>
    public void ChangeRotation(Vector3 v)
    {
        yaw = v.y;
        pitch = v.x;
        transform.eulerAngles = v;
        player.transform.eulerAngles = new Vector3(0, yaw, 0);
    }
}
