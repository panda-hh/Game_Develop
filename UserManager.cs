using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserManager : MonoBehaviour
{
    private static UserManager _instance;
    public static UserManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<UserManager>();
            }
            return _instance;

        }
    }
    [SerializeField]
    private GameObject sleepy;

    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreTxt;

    [SerializeField]
    private TextMeshProUGUI bestScore;

    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject button;


    public void Start()
    {
        StartCoroutine(CreatesleepyRoutine());
        score = 0;
        PlayerPrefs.SetInt("점수", score);
        bestScore.text = PlayerPrefs.GetInt("점수", 0).ToString();
    }
    void Update()
    {

    }
    public bool stopTrigger = true;

    public void GameOver()
    {
        stopTrigger = false;
        StopCoroutine(CreatesleepyRoutine());
        if (score >= PlayerPrefs.GetInt("점수", 0))
        PlayerPrefs.SetInt("점수", score);


        if(score>=40)
        {
            button.SetActive(true);
        }

        bestScore.text = PlayerPrefs.GetInt("점수", 0).ToString();

        score = 0;
        scoreTxt.text = "학습시간 : " + score + "분";

        panel.SetActive(true);
    }
    public void GameStart()
    {
        stopTrigger = true;
        StartCoroutine(CreatesleepyRoutine());
        panel.SetActive(false);
    }

    public void Score()
    {
        score++;
        scoreTxt.text = "학습시간 : " + score+ "분";
    }
     
    IEnumerator CreatesleepyRoutine()
    {
        while (stopTrigger)
        {
            CreateSleepy();
            yield return new WaitForSeconds(0.3f);
        }
    }
        
    private void CreateSleepy()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0) );
        pos.z = 0.0f;
        Instantiate(sleepy, pos, Quaternion.identity);
    }
}
