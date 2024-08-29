using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public NejikoController nejiko;
    //public Text scoreText; ���ꂾ�ƁA�e�L�X�g���b�V���v���͓���Ȃ�
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

        //�l�W�R�̃��C�t��0�ɂȂ�����game�I�[�o�[
        if (nejiko.Life() <= 0)
        {
            //����ȍ~��update�͎~�߂�i����Update�͂Ȃ��ɂ���j
            //this..enabled�Ł@GameController���g���Ƃ߂�
            this.enabled = false;

            //�n�C�X�R�A�X�V(�����l���傫����΁H)
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("Highscore", score);
            }


            //�Q�b���ReturnToTitle���\�b�h���Ăяo��
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
