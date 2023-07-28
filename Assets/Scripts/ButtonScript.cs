using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    CanvasConroller canvasConroller;
    Bounce bounce;

    void Start()
    {
        canvasConroller = FindObjectOfType<CanvasConroller>();
        bounce = FindObjectOfType<Bounce>();
    }

    public void OnMouseOver()
    {
        //canvasConroller.isScriptFalse = true;
        bounce.enabled = false;
    }

    public void OnMouseExit()
    {
        //canvasConroller.isScriptFalse = false;
        bounce.enabled = true;
    }
}
