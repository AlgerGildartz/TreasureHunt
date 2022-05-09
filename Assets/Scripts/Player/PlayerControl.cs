using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [Tooltip("Walk speed when moving forward")]
    public float walkSpeed;
    [Tooltip("Force given to the player for a jump")]
    public int jumpForce;


    /// <summary>
    /// Check if the user is tring to move and move the player in consequence
    /// </summary>
    void Move()
    {
        // Vertical Axis
        if (Input.GetButton("Vertical"))
        {
            // Go forward
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime * (Input.GetButton("Fire3") ? 2 : 1));
            }

            // Go back
            if (Input.GetAxis("Vertical") < 0)
            {
                transform.Translate(Vector3.back * walkSpeed * (3.0f / 4.0f) * Time.deltaTime);
            }
        }

        // Horizontal Axis
        if (Input.GetButton("Horizontal"))
        {
            // Go left
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Translate(Vector3.left * walkSpeed * (1.0f / 2.0f) * Time.deltaTime);
            }

            // Go right
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Translate(Vector3.right * walkSpeed * (3.0f / 4.0f) * Time.deltaTime);
            }
        }
    }

    /// <summary>
    /// Check if the user is tring to pause the game
    /// </summary>
    void CheckPause()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Menu.TabMenu.ShowTab(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Menu.TabMenu.ShowTab(false);
        }

    }

    public void Pause()
    {
        Menu.PauseMenu.GamePause();
    }

    /***********************************
     * Script functions              *
     ***********************************/

    // Update is called once per frame
    void Update()
    {
        CheckPause();
        if (!Menu.IsOnPause())
        {
            Move();
        }

    }
}
