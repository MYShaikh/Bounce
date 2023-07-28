using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bounce : MonoBehaviour
{
    public int Lives;
    public float Score;

    [SerializeField] public AudioSource audioBounce;

    NextLevel nextLevel;
    CanvasConroller canvasConroller;
    
    [SerializeField] public GameObject audioLoose;
    [SerializeField] public GameObject audioMusic;

    public bool IsDead;

    // public GameObject BirdRight;
    // public GameObject BirdLeft;
    public bool isFlip;

    public float Timer;
    public float TimeSeconds;
    public string TextValue;
    [SerializeField] public TextMeshPro textElement;
    public float Minutes;
    public float LevelNum;
    public string TextValue2;
    [SerializeField] public TextMeshPro textElement2;

    public bool StartRotate;

    public Rigidbody2D rb;

    [SerializeField] public GameObject Cimimachine;

    [SerializeField] private CircleCollider2D cc2d;
    [SerializeField] private float Speed;

    public float RotationSpeed;
    public float Rotations;

    public float RotZ;

    public Transform target;
    CanvasConroller cc;

    //public Vector3 mouse_Position;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 newRotation = new Vector3(0, 0, -85);
        transform.eulerAngles = newRotation;
        IsDead = false;
        Lives = 3;
        RotationSpeed = 600f;
        Rotations = 30f;

        isFlip = false;

        nextLevel = FindObjectOfType<NextLevel>();
        canvasConroller = FindObjectOfType<CanvasConroller>();

        TimeSeconds = 120f;
        TextValue2 = SceneManager.GetActiveScene().name;
        TextValue2 = TextValue2.Substring(TextValue2.Length - 1);
        

        textElement.text = TextValue;
        textElement2.text = "Level " + TextValue2;

        GetComponent<Rigidbody2D>().isKinematic = true;

        StartRotate = false;
        // BirdLeft = transform.GetChild(0).gameObject;
        // BirdRight = transform.GetChild(1).gameObject;
        cc = FindObjectOfType<CanvasConroller>();

        cc2d = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Timer = Timer + Time.deltaTime;

        if(TextValue != "0" & !nextLevel.LevelCleared)
        {
            TimeSeconds = TimeSeconds - Time.deltaTime;
            Timer = TimeSeconds;
        }
        else if(TextValue == "0")
        {
            Dead();
        }

        RotZ = transform.rotation.z;
        if(RotZ == 1)
        {
            Debug.Log("1");
        }

        if(IsDead)
        {
            audioLoose.SetActive(true);
            audioMusic.SetActive(false);
        }
        

        if(Lives > 0)
        {
            //TextValue = Timer;

            TextValue = Timer.ToString("F0");
            textElement.text = TextValue;



            if(StartRotate == false && Time.timeScale == 1 && !rb.isKinematic)
            {
                transform.up = target.position - transform.position;
            }

            // if(transform.rotation.z > 0 )
            // {
            //     // BirdLeft.SetActive(true);
            //     // BirdRight.SetActive(false);
            //     isFlip = true;
            // }
            // if(transform.rotation.z < 0 || transform.rotation.z > 0.85f && transform.rotation.z < 0.99f)
            // {
            //     // BirdLeft.SetActive(false);
            //     // BirdRight.SetActive(true);
            //     isFlip = false;
            // }
            Debug.Log(transform.position.y);
            if(Input.GetMouseButtonDown(0) && (transform.position.y < 20f))
            {
                
                GetComponent<Rigidbody2D>().isKinematic = false;
                Shoot(transform.up);
            }
            // if(Input.GetMouseButtonUp(0))
            // {
            //     Shoot(transform.up);
            // }

            // if(Input.touchCount > 0)
            // {
            //     Shoot(transform.up);
            // }
        }
        if(Lives <= 0)
            Dead();
    }

    public void Shoot(Vector2 dir)
    {
        if(canvasConroller.HasBeenTriggered == false)
            rb.velocity = dir * Speed;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Lives = Lives - 1;
        cc.RemoveOneLife();
        audioBounce.Play();
    }

    public void Dead()
    {
        Score = 0;
        Lives = 0;
        IsDead = true;
        Rotations += Time.deltaTime * RotationSpeed;
        transform.rotation = Quaternion.Euler(0,0, Rotations);
        Cimimachine.SetActive(false);
        StartRotate = true;
        cc2d.enabled = false;
    }
    
}
