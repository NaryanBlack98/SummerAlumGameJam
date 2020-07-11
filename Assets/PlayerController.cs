using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 20;
    public float range = 17;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (Input.GetKey(KeyCode.L))
        {
            Collider[] inRange = Physics.OverlapSphere(transform.position, range, 11);

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
}
