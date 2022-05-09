using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Item
{
    [SerializeField]
    private float speed = 0.2f;
    [SerializeField]
    private GameObject player;

    private bool move;
    private Vector3 forward;

    private const float BIG_SIZE = 1.5f;
    private const float SMALL_SIZE = 1f;

    private void Start()
    {
        move = false;
        forward = new Vector3(0, 0, 0);
    }

    public override void OnInteraction()
    {
        Vector3 direction = transform.position - player.transform.position;

        forward = Forward(direction);
        ChangeCollider();
        move = true;
    }

    private void FixedUpdate()
    {
        if (move)
        {
            transform.Translate(forward * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 9)
        {
            move = false;
            GetComponent<BoxCollider>().size = new Vector3(BIG_SIZE, SMALL_SIZE, BIG_SIZE);
        }
    }

    private void ChangeCollider()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        if (forward.z != 0)
        {
            collider.size = new Vector3(SMALL_SIZE, SMALL_SIZE, BIG_SIZE);
        }
        else if(forward.x != 0)
        {
            collider.size = new Vector3(BIG_SIZE, SMALL_SIZE, SMALL_SIZE);
        }
    }

    private Vector3 Forward(Vector3 v)
    {
        float x = Math.Abs(v.x);
        float z = Math.Abs(v.z);

        if (x > z)
        {
            return new Vector3(Math.Sign(v.x), 0, 0);
        }
        else
        {
            return new Vector3(0, 0, Math.Sign(v.z));
        }
    }
}
