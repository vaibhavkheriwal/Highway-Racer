using System;
using System.Collections;
using TMPro;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    float scoreCount = 0;
    bool wait = false;
    void Start()
    {
        StartCoroutine(Wait());
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null && Time.timeScale == 1 && wait == true)
        {
            scoreCount = scoreCount + 0.2f;
            score.text = (int) Math.Truncate(scoreCount) + "";
        }
        if (GameObject.FindGameObjectWithTag("Player") == null && PlayerPrefs.GetFloat("highScore") < scoreCount)
        {
            PlayerPrefs.SetFloat("highScore", scoreCount);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        wait = true;
    }
}