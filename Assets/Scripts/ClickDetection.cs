using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClickDetection : MonoBehaviour
{
    AudioSource maiasButt; 
    public bool clicked = false;
    void OnMouseDown()
    {
        maiasButt = GetComponent<AudioSource>();
        maiasButt.Play(0);
        //if (this.GameObject.name == "Trash")
      //  {
            
       // }
       // else if(this.GameObject.name == "phoneOpen")
      //  {

     //   }
      //  else if(this.GameObject.name == "BrocollionPlate")
      //  {

      //  }
        clicked = true;
        UnityEngine.Debug.Log("clicked");
    }
}
