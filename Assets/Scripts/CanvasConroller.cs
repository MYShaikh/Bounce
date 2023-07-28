using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CanvasConroller : MonoBehaviour
{
    NextLevel next;

    public GameObject Live;
    public GameObject Cinemachine;

    Bounce bounce;
    Mouse mouse;
    public bool isScriptFalse;

    public bool GameOver;

    public bool HasBeenTriggered;

    public GameObject LooseButtons;
    public GameObject ResumeButtons;

    public UnityEvent GamePaused;
    public UnityEvent GameResumed;

    // Start is called before the first frame update
    void Awake()
    {
        LooseButtons.SetActive(false);
        ResumeButtons.SetActive(false);
    }

    void Start()
    {
        next = FindObjectOfType<NextLevel>();
        mouse = FindObjectOfType<Mouse>();

        GameOver = false;
        isScriptFalse = true;
        HasBeenTriggered = false;

        Live = transform.GetChild(0).gameObject;
        bounce = FindObjectOfType<Bounce>();
    }

    public void Update()
    {
        if(isScriptFalse)
            bounce.enabled = true;
        if(!isScriptFalse)
            bounce.enabled = false;
            
        Live = transform.GetChild(0).gameObject;
        if(Cinemachine.activeSelf == false)
        {
            Invoke("Buttons",3f);
        }
    }

    // Update is called once per frame
    public void RemoveOneLife()
    {
        Destroy(Live);
        Invoke("Trig",0.1f);
    }

    public void Buttons()
    {
        HasBeenTriggered = true;
        GameOver = true;
        LooseButtons.SetActive(true);
        Invoke("Trig",0.1f);
        // mouse.BackupPosition();
    }

    public void RestartLevel()
    {
        HasBeenTriggered = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        HasBeenTriggered = false;
    }

    public void PauseGame()
    {
        //mouse.BackupPosition();
        HasBeenTriggered = true;
        if(!GameOver & !next.LevelCleared)
        {
            Time.timeScale = 0;
            GamePaused.Invoke();
            ResumeButtons.SetActive(true);
        }
        //isScriptFalse = false;
        //gameObject.Find("Bounce").GetComponent<Bounce>().enabled = false;
    }

    public void Trig()
    {
        HasBeenTriggered = false;
    }

    public void PlayGame()
    {
        //mouse.BackupPosition();
        HasBeenTriggered = true;
        ResumeButtons.SetActive(false);
        Time.timeScale = 1;
        GameResumed.Invoke();
        Invoke("Trig",0.1f);
    }
}
