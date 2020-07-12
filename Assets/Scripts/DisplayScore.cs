using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    TextMesh t;
    // Start is called before the first frame update
    void Start()
    {
        ZombeManager zomMan = GameObject.Find("ZombeManager").GetComponent<ZombeManager>();
        t = GetComponent<TextMesh>();
        t.text += " " + zomMan.totalWaves;
        GameObject.Destroy(zomMan.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
