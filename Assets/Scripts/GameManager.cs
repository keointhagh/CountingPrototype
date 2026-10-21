using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> pooledObjects { get; private set; }
    public GameObject objectToPool;
    public int amountToPool;
    private int numBallsActive;
    private int totalScore;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI ballsLeftText;
    private bool isGameActive;
    [SerializeField] GameObject startButton;
    private GameObject gameTitle;
    [SerializeField] private GameObject restartButton;

    void StartGame()
    {

        //GameObject obj;
        //for (int i = 0; i < pooledObjects.Count; i++)
        foreach (GameObject obj in pooledObjects)
        {
            //GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
        }
        numBallsActive = pooledObjects.Count;
        ballsLeftText.text = "Balls Left:\n" + numBallsActive;
        totalScore = 0;
        scoreText.text = "Score:\n" + totalScore;

        isGameActive = true;
        startButton.SetActive(false);
        gameTitle.SetActive(false);
        restartButton.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        ballsLeftText = GameObject.Find("BallsLeft").GetComponent<TextMeshProUGUI>();
        //startButton = GameObject.Find("StartGame");
        //restartButton = GameObject.Find("RestartGame");
        gameTitle = GameObject.Find("Title");

        startButton.GetComponent<Button>().onClick.AddListener(StartGame);
        restartButton.GetComponent<Button>().onClick.AddListener(StartGame);

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        numBallsActive = pooledObjects.Count;
        ballsLeftText.text = "Balls Left:\n" + numBallsActive;
        totalScore = 0;

        isGameActive = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }
    void GameOver()
    {
        isGameActive = false;
        gameTitle.SetActive(true);
        restartButton.SetActive(true);
    }
    public void decreaseActiveBalls()
    {   
        numBallsActive--;
        ballsLeftText.text = "Balls Left:\n" + numBallsActive;
        if (numBallsActive <= 0) GameOver();
    }
    public bool isActive()
    {
        return isGameActive;
    }

    public void UpdateScore(int addScore)
    {
        GetComponent<AudioSource>().Play();
        totalScore += addScore;
        scoreText.text = "Score:\n" + totalScore;
    }
}
