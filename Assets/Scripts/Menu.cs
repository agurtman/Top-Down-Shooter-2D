using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    List<string> dropText = new List<string>() { "Menu", "Walkthrough", "Survive" };
    [SerializeField] Dropdown dropdown;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject text;
    [SerializeField] Slider bar;
    [SerializeField] GameObject pauseUI;
    private bool pause;
    private Player player;

    void Start()
    {
        if (dropdown != null)
            dropdown.AddOptions(dropText);

        player = Player.instance;
        Time.timeScale = 1;
    }

    public void LoadDropLevel(int index)
    {
        ui.SetActive(true);
        StartCoroutine(waitScene(index));
    }

    public void StartGame()
    {
        ui.SetActive(true);
        StartCoroutine(waitScene(1));
    }

    public void Pause()
    {
        if (!pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            player.enabled = false;
            pause = true;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
            player.enabled = true;
            pause = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Stats.ResetAllStats();
    }

    IEnumerator waitScene(int index)
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(index);
        loadScene.allowSceneActivation = false;
        while (!loadScene.isDone)
        {
            bar.value = loadScene.progress;
            if (loadScene.progress >= .9f)
            {
                text.SetActive(true);
                if (Input.anyKeyDown)
                {
                    loadScene.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }
}
