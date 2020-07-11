using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ZombeAI : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    public float zomSpeed = 80;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;
        transform.LookAt(player.transform.position);

        rb.AddForce(transform.forward * Time.deltaTime * zomSpeed, ForceMode.VelocityChange);
    }
}
