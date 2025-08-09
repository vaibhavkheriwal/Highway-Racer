using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject play;
    [SerializeField] GameObject exit;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] TextMeshProUGUI score;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        score.text = (int)Math.Truncate(PlayerPrefs.GetFloat("highScore", 0)) + "";
    }
    public void PlayButton()
    {
        StartCoroutine(Wait());
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    IEnumerator Wait()
    {
        play.SetActive(false);
        exit.SetActive(false);
        highScore.text = "Loading...";
        score.text = "";
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(1);
    }
}