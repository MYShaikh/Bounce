using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Flip : MonoBehaviour, IPointerDownHandler
{
    //Bounce bou;
    Bounce bo;
    Mouse mouse;
    CanvasConroller canvasConroller;

    public GameObject Bird;

    public Button b;
    public SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        Bird = GameObject.Find("Bounce");
        rend = GameObject.Find("BouncyBird").GetComponent<SpriteRenderer>();
        bo = FindObjectOfType<Bounce>();
        b = gameObject.GetComponent<Button>();
        canvasConroller = FindObjectOfType<CanvasConroller>();
        mouse = FindObjectOfType<Mouse>();
        // if(gameObject.name == "Right")
        // {
        //     Debug.Log("a");
        //     b.onClick.AddListener(FlipRight);
        // }
        // if(gameObject.name == "Left")
        // {
        //     Debug.Log("b");
        //     b.onClick.AddListener(FLipLeft);
        // }
            
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name == "Left" && !canvasConroller.HasBeenTriggered)
        {
            bo.isFlip = true;
            //mouse.BackupUpdate();
            Debug.Log("lll");
            //bo.Shoot(Bird.transform.up);
        }

        if(gameObject.name == "Right" && !canvasConroller.HasBeenTriggered)
        {
            bo.isFlip = false;
            //mouse.BackupUpdate();
            Debug.Log("rrr");
            //bo.Shoot(Bird.transform.up);
        }
    }

    // public void FLipLeft()
    // {
    //     //rend.flipY = true;
    //     // bo.isFlip = true;
    // }

    // public void FlipRight()
    // {
    //     //rend.flipY = false;
    //     // bo.isFlip = false;
    // }

    // Update is called once per frame
}
