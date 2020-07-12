using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClickDetection : MonoBehaviour
{
    public bool clicked = false;
    void OnMouseDown()
    {
        clicked = true;
        UnityEngine.Debug.Log("clicked");
    }
}
