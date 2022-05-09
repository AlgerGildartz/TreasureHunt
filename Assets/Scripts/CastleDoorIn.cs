using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDoorIn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] endFloor;
    [SerializeField]
    private bool lastDoor;


    private readonly string[] colors = { "Red", "Blue", "Green"};
    private bool allBlocs = false;

    private void Update()
    {
        allBlocs = true;
        // Check if all blocks are corectly placed
        for (int i = 0; i < endFloor.Length; i++)
        {
            if (!IsPlaced(i))
            {
                allBlocs = false;
                break;
            }
        }

        if (allBlocs)
        {
            // If it's the last room
            if (lastDoor)
            {
                gameObject.transform.localPosition = new Vector3(49765.92f, -81.789f, -1123.04f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if(lastDoor)
                gameObject.transform.localPosition = new Vector3(49765.92f, -90.789f, -1123.04f);
        }
    }

    /// <summary>
    /// Check if the corresponding block is placed on the right tile
    /// </summary>
    /// <param name="index">Actual tile</param>
    /// <returns></returns>
    private bool IsPlaced(int index)
    {
        RaycastHit hit;
        Physics.Raycast(endFloor[index].transform.position, Vector3.up, out hit);
        if (hit.collider != null)
        {
            return hit.collider.tag == colors[index];
        }
        else
        {
            return false;
        }
    }
}
