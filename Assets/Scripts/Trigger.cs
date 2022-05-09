using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obj;
    [SerializeField]
    private bool[] order;

    private bool done = false;

    private bool current = true;
    private bool previous = false;

    // Update is called once per frame
    void Update()
    {
        if (current = CubeOn())
        {
            if (!done)
            {
                // All game change
                for (int i = 0; i < obj.Length; i++)
                {
                    if (order[i])
                    {
                        Shrink(obj[i]);
                    }
                    else
                    {
                        Grow(obj[i]);
                    }
                }

                done = true;
            }
        }
        if(previous && !current)
        {
            // All game change
            for (int i = 0; i < obj.Length; i++)
            {
                if (order[i])
                {
                    Grow(obj[i]);
                }
                else
                {
                    Shrink(obj[i]);
                }
            }
            done = false;
        }
        previous = current;
    }

    private bool CubeOn()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.up, out hit);
        if (hit.collider != null)
        {
            if (hit.collider.tag != "Player")
            {
                return true;
            }
        }
        return false;
    }

    private void Grow(GameObject o)
    {
        o.SetActive(true);
    }

    private void Shrink(GameObject o)
    {
        o.SetActive(false);
    }
}
