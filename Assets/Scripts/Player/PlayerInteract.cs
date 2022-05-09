using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [Tooltip("The camera")]
    public Camera myCam;
    [Tooltip("Layer to pick up")]
    public LayerMask layer;

    private GameObject toInteract;

    // Update is called once per frame
    void Update()
    {
        if (!Menu.IsOnPause())
        {
            SelectItemToInteract();

            if (HasItemTarget())
            {
                Menu.TextInfo.ShowText(true);

                if (Input.GetButtonDown("Fire1"))
                {
                    InteractItem();
                }
            }
            else
            {
                Menu.TextInfo.ShowText(Menu.TextInfo.isLocked());
            }
        }
    }

    /// <summary>
    /// Check if there's an interactable object in front of the player
    /// </summary>
    void SelectItemToInteract()
    {
        Ray ray = myCam.ViewportPointToRay(Vector3.one / 2f);

        RaycastHit hitInfo;

        bool test = Physics.Raycast(ray, out hitInfo, 2f, layer);

        if (test)
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
            GameObject hitItem = hitInfo.collider.gameObject;
            if (hitItem == null)
            {
                toInteract = null;
            }
            else if (hitItem != toInteract)
            {
                toInteract = hitItem;
                Menu.TextInfo.ChangeText("Click to interact with " + toInteract.GetComponent<Item>().GetName());
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            toInteract = null;
        }
    }

    bool HasItemTarget()
    {
        return toInteract != null;
    }

    void InteractItem()
    {
        Item i = toInteract.GetComponent<Item>();

        if (i != null)
        {
            i.OnInteraction();
        }
    }
}
