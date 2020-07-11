using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    public float gunRange = 17;
    public float craftRange = 2;
    public float reloadTime = 1.5f;
    public float fireDelay = 0.2f;
    public int ammoCap = 6;
    public int wood = 0;

    private Rigidbody rb;
    private GameObject spriteHolder;
    private int ammo;
    private bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteHolder = GetComponentInChildren<Collider>().gameObject;
        ammo = ammoCap;
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

        // Shoot / Reload
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (ammo > 0 && !shooting)
            {
                Shoot();
            } else if (ammo == 0)
            {
                ammo = -1;
                StartCoroutine("Reload");
            }
        }

        // Crafting
        if (Input.GetKey(KeyCode.K))
        {
            Craft();
        }

    }

    private void Craft()
    {
        Collider[] trees = Physics.OverlapSphere(transform.position, craftRange, LayerMask.GetMask("Tree"));

        if (trees.Length == 0)
        {

        } else
        {

        }
    }
    
    private void Shoot()
    {
        Collider[] inRange = Physics.OverlapSphere(transform.position, gunRange, LayerMask.GetMask("Zombe"));

        if (inRange.Length > 0)
        {
            GameObject closest = inRange[0].gameObject;
            float closeNum = gunRange + 1;
            foreach (Collider c in inRange)
            {
                float dist = Vector3.Distance(c.gameObject.transform.position, transform.position);
                if (dist < closeNum)
                {
                    closest = c.gameObject;
                    closeNum = dist;
                }
            }
            if (closest != null)
            {
                GameObject.Destroy(closest);
                ammo--;
                shooting = true;
                StartCoroutine("LimitFireRate");
            }
            spriteHolder.transform.LookAt(closest.transform.position);
        } else if (ammo != ammoCap)
        {
            ammo = -1;
            StartCoroutine("Reload");
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        ammo = ammoCap;
    }

    private IEnumerator LimitFireRate()
    {
        yield return new WaitForSeconds(fireDelay);
        shooting = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, gunRange);
    }
}
