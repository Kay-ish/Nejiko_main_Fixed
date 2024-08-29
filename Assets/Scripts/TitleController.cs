using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class TitleController : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    public void Start()
    {
        highScoreText.text = "High Score :" + PlayerPrefs.GetInt("Highscore") + "m";
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        Start();
    }

    //ÉQÅ[ÉÄèIóπ
    public void EndClicked()
    {

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

}
    