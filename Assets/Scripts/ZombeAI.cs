﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class ZombeAI : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    public float zomSpeed = 130;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        transform.LookAt(player.transform.position);

        rb.AddForce(transform.forward * Time.deltaTime * zomSpeed, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DudeHolder")
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("EndGame");
        }
    }
}
