using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        ZombeManager zomMan = GameObject.Find("ZombeManager").GetComponent<ZombeManager>();
        t = GetComponent<TextMeshProUGUI>();
        t.text += " " + zomMan.totalWaves;
        GameObject.Destroy(zomMan.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
