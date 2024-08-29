using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public NejikoController nejiko;
    //public Text scoreText; これだと、テキストメッシュプロは入らない
    public TMP_Text scoreText;
    public LifePanel lifePanel;

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

        int score = CalcScore();
        scoreText.text = "Score :" + score + "m";

        lifePanel.UpdateLife(nejiko.Life());

        //ネジコのライフが0になったらgameオーバー
        if (nejiko.Life() <= 0)
        {
            //これ以降のupdateは止める（次のUpdateはなしにする）
            //this..enabledで　GameController自身をとめる
            this.enabled = false;

            //ハイスコア更新(初期値より大きければ？)
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("Highscore", score);
            }


            //２秒後にReturnToTitleメソッドを呼び出す
            Invoke("ReturnToTitle", 2.0f);
        }




    }

    int CalcScore()
    {
        return (int)nejiko.transform.position.z;
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }

      

}
