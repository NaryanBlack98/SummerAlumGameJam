using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private int health = 3;
    // Offset from player
    [SerializeField]
    private float offset = 1.76f;

    // Update is called once per frame
    void Update()
    {
        // Bad code to move the ghost
        if (transform.parent != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.localPosition = new Vector3(0, 0, offset);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.localPosition = new Vector3(-offset, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.localPosition = new Vector3(0, 0, -offset);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.localPosition = new Vector3(offset, 0, 0);
            }
        }

        else
        {
            // Crate logic
            if (health == 0)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
