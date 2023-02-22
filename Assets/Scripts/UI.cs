using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject GameEndPanel;

    public Transform player;
    public Text nowDepthTxt;
    public Text overDepthTxt;
    public Text endDepthTxt;
    public GameObject[] HP = new GameObject[3];

    float nowdepth = 0;

    private static UI _instance;
    public static UI instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UI>();
            }
            return _instance;
        }

    }

    void Start()
    {
        for(int i=0; i<PlayerMove.hp; i++)
        {
            HP[i].SetActive(true);
        }

        StartPanel.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Sound.instance.UIBtn();
            Time.timeScale = 0;
            //popup pause panel
            PausePanel.SetActive(true);
        }
        if (player.position.y < nowdepth)
        {
            nowdepth = player.position.y;
            nowDepthTxt.text = (-nowdepth).ToString("F2") + " m";
        }

        if (PlayerMove.hp < 3)
        {
            HP[PlayerMove.hp].SetActive(false);
        }
    }


    public void StartGame()
    {
        StartPanel.SetActive(false);
    }
    public void ContinueBtn()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        //스코어 기록
        overDepthTxt.text = nowDepthTxt.text;
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        Item.is_end = false;
        PlayerMove.hp = 3;
        Time.timeScale = 1;
        SceneManager.LoadScene("TieTheRope");
    }

    public void GameEnd()
    {
        Item.is_end = true;
        GameEndPanel.SetActive(true);
        endDepthTxt.text = nowDepthTxt.text;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
