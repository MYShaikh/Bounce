using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public bool LevelCleared;
    public float Score;
    [SerializeField] public TextMeshPro ScoreText;
    [SerializeField] public GameObject ScoreBoard;

    public bool HasBeenTriggered;
    public AudioSource Cheers;

    Bounce bounce;
    // Start is called before the first frame update
    void Start()
    {
        ScoreBoard.SetActive(false);
        HasBeenTriggered = false;
        LevelCleared = false;

        bounce = FindObjectOfType<Bounce>();
        //TextValue = Timer.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ScoreBoard.SetActive(true);
        LevelCleared = true;
        bounce.Score = (bounce.TimeSeconds * 100) + (bounce.Lives * 200);
        Score = (bounce.TimeSeconds * 100) + (bounce.Lives * 200);
        ScoreText.text = Score.ToString("F0");
        Debug.Log(bounce.Score);
        if(HasBeenTriggered == false)
        {
            HasBeenTriggered = true;
            Cheers.Play();
            Invoke("ChangeLevel",5f);
        }
    }

    void ChangeLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene("Level_4");
    }
}
