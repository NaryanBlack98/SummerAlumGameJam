﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject spriteHolder;
    public float speed = 20;
    public float range = 17;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteHolder = GetComponentInChildren<BoxCollider>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        float delt = Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(speed * Vector3.forward * delt, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(speed * Vector3.left * delt, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(speed * Vector3.back * delt, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed * Vector3.right * delt, ForceMode.VelocityChange);
        }

        // Shoot
        if (Input.GetKeyDown(KeyCode.L))
        {
            Collider[] inRange = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Zombe"));

            if (inRange.Length > 0) {
                GameObject closest = inRange[0].gameObject;
                float closeNum = range + 1;
                foreach (Collider c in inRange)
                {
                    float dist = Vector3.Distance(c.gameObject.transform.position, transform.position);
                    if (dist < closeNum)
                    {
                        closest = c.gameObject;
                        closeNum = dist;
                    }
                }
                if (closest != null) GameObject.Destroy(closest);
                spriteHolder.transform.LookAt(closest.transform.position);
            }


        }
        // Crafting
        if (Input.GetKey(KeyCode.J))
        {
            
        }
        // Reload
        if (Input.GetKey(KeyCode.K))
        {
            
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
