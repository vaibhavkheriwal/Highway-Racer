using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject androidButtons;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] TextMeshProUGUI gameOver;
    [SerializeField] bool inAndroid;
    bool countdownStart = false;
    bool countdownEnd = false;
    void Start()
    {
        if (inAndroid)
        {
            androidButtons.SetActive(true);
        }
        else
        {
            androidButtons.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        Application.targetFrameRate = 60;
        pauseMenu.SetActive(false);
        StartCoroutine(Countdown(false));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("Player") != null)
        {
            PauseAndResume();
        }
        else if (GameObject.FindGameObjectWithTag("Player") == null && !countdownEnd)
        {
            gameOver.enabled = true;
            countdown.enabled = true;
            StartCoroutine(Countdown(true));
            if (inAndroid)
            {
                androidButtons.SetActive(false);
            }
            countdownEnd = true;
        }
    }
    public void PauseAndResume()
    {
        if (Time.timeScale == 1)
        {
            if (!inAndroid)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            countdown.enabled = false;
        }
        else
        {
            if (!inAndroid)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            if (!countdownStart)
            {
                countdown.enabled = true;
            }
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator Countdown(bool isGameEnd)
    {
        countdown.text = "1";
        yield return new WaitForSeconds(1);
        countdown.text = "2";
        yield return new WaitForSeconds(1);
        countdown.text = "3";
        yield return new WaitForSeconds(1);
        if (!isGameEnd)
        {
            countdown.enabled = false;
            countdownStart = true;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}