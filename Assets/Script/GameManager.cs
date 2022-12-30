using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("--- LEVEL OBJECTS")]
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject basket;
    [SerializeField] private GameObject basketSizeIncreaseBuff;
    [SerializeField] private GameObject[] buffPlaces;
    [SerializeField] private AudioSource[] sounds;
    [SerializeField] private ParticleSystem[] effects;

    [Header("--- UI OBJECTTS")]
    [SerializeField] private GameObject[] panels;
    [SerializeField] private TextMeshProUGUI scoreText;

    int scoreCount;
    int highScore;
    float fingerPosX;

    void Start()
    {

        scoreText.SetText("Score: {0}", scoreCount);

        InvokeRepeating("CreateBuff", 0, 20);
    }

    void CreateBuff()
    {
        int RandomNumber = Random.Range(0, buffPlaces.Length - 1);

        basketSizeIncreaseBuff.transform.position = buffPlaces[RandomNumber].transform.position;
        basketSizeIncreaseBuff.SetActive(true);
    }
    void Update()
    {
        /*if (Time.timeScale != 0)
        {

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToViewportPoint(new Vector3(touch.position.x, touch.position.y, 10));

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        fingerPosX = touchPosition.x - platform.transform.position.x;
                        break;

                    case TouchPhase.Moved:
                        if (touchPosition.x - fingerPosX > -1.35 && touchPosition.x - fingerPosX < 1.35)
                        {
                            platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(touchPosition.x - fingerPosX, platform.transform.position.y, platform.transform.position.z), 0.90f);
                        }

                        break;
                }
            }*/

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (platform.transform.position.x > -1.35)
            {
                platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x - .9f, platform.transform.position.y, platform.transform.position.z), .050f);

            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            if (platform.transform.position.x < 1.35)
            {
                platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x + .9f, platform.transform.position.y, platform.transform.position.z), .050f);
            }
        }

    }

    void UpdateScore(int score)
    {
        scoreText.SetText("Score: {0}", score);
    }
    public void Score(Vector3 pos)
    {
        sounds[4].Play();
        scoreCount++;
        UpdateScore(scoreCount);
        effects[0].transform.position = pos;
        effects[0].gameObject.SetActive(true);

    }

    public void GameOver()
    {
        sounds[1].Play();
        panels[2].SetActive(true);
        Time.timeScale = 0;
    }

    public void IncreaseBasketSize(Vector3 pos)
    {
        sounds[0].Play();
        effects[1].transform.position = pos;
        effects[1].gameObject.SetActive(true);
        basket.transform.localScale = new Vector3(55f, 55f, 55f);
        StartCoroutine(StartingBasketSize());
    }

    IEnumerator StartingBasketSize()
    {
        yield return new WaitForSeconds(5f);

        basket.transform.localScale = new Vector3(50f, 50f, 50f);
    }

    public void ButtonOperations(string value)
    {
        switch (value)
        {
            case "Stop":
                Time.timeScale = 0;
                panels[0].SetActive(true);
                sounds[3].Pause();
                break;
            case "Resume":
                Time.timeScale = 1;
                panels[0].SetActive(false);
                sounds[3].Play();
                break;
            case "TryAgain":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;
            case "Quit":
                Application.Quit();
                break;
        }
    }

}





