using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GameStatus : MonoBehaviour
{
    //Config Params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83; 
    //State
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] public bool autoPlay = false; 

    private void Awake()
    {
        // Singleton to keep score accross levels. 
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            // Here we set the gameObject to inactive. This is to prevent multiple conflicting instances of GameStatus object
            // as the frame lifecycle calls Destroy at the very end of the first frame.
            gameObject.SetActive(false); 
            Destroy(gameObject); 
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed; 
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString(); 
    }

    public void ResetGame()
    {
        Destroy(gameObject); 
    }
}
