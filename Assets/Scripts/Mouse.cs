using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    //public Vector2 MouseCoords;
    //public GameObject ResumeButtons;
    // Start is called before the first frame update

    public GameObject Target;
    CanvasConroller canvasConroller;

    public Vector2 Var1;
    public Vector2 Var2;
    //public Vector2 MouseCoords;
    
    void Start()
    {
        canvasConroller = FindObjectOfType<CanvasConroller>();
        //MouseCoords = new Vector2(0,0);
        Var1 = new Vector2(0,0);
        Var2 = new Vector2(0,0);
    }

    // Update is called once per frame
    
    void Update()
    {
        {
            Vector2 MouseCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = MouseCoords;
        }
        
        //if(Input.GetMouseButtonDown(0))
        //{
            //Instantiate(Target, MouseCoords, Quaternion.identity);
            //Destroy(GameObject.FindWithTag("Target"));
        //}
        // if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        // {
        //     Touch touch = Input.GetTouch(0);
        //     Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //     transform.position = touchPosition;
        // }

    }

    // public void BackupUpdate()
    // {
    //     Var2 = Var1;
    //     Var1 = MouseCoords;
    // }

    // public void BackupPosition()
    // {
    //     transform.position = new Vector2(Var2.x,Var2.y);
        
    //     if( new Vector2 (transform.position.x,transform.position.y) == Var2)
    //         Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    // }
}
