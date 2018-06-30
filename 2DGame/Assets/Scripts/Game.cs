using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
*ゲームの遷移を管理するクラス
*/
public class Game : MonoBehaviour
{
    // Gameクラスの唯一のインスタンス
    private static Game mInstance;
    //プレイヤー人数
    public static int ply_cnt;

    /*Gameのインスタンスを返すパブリックな関数
	*(staticでpublicなので、どのソースコードからでも呼ぶことができる)
	*/
    public Text highScoreText; //ハイスコアを表示するTextオブジェクト
    private int highScore; //ハイスコア計算用変数
    private string[] key = { "Stage1_HIGH SCORE", "Stage2_HIGH SCORE", "Stage3_HIGH SCORE" }; //ハイスコアの保存先キー
  

    public static Game instance
    {

        get
        {
            //インスタンスが参照されているか
            if (mInstance == null)
            {
                //インスタンスを探し、参照する
                mInstance = FindObjectOfType<Game>();
            }
            //インスタンスを返す
            return mInstance;
        }
    }
    //ゲームの状態
    public enum STATE
    {
        NONE, //何もない状態
        START, //スタートの状態
        MOVE, //ゲーム中の状態
        GAMEOVER //ゲームオーバーの状態
    };
    //ゲームの状態
    public STATE state
    {
        get;
        set;
    }

    private Text mText;

    /*
	*はじめに呼ばれる関数
	*/
    void Start()
    {

        mText = GetComponent<Text>();

        //ゲームの状態をスタートに
        state = STATE.START;
        //StartCountDownを呼び出す
        StartCoroutine("StartCountDown");

        //保存しておいたハイスコアをキーで呼び出し取得
        //保存されていなければ0が返る
        highScore = PlayerPrefs.GetInt(key[PlayerController.stageNo], 0);
        
        //ハイスコアを表示
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    /*
	*毎回呼ばれる関数
	*/
    void Update()
    {
        switch (state)
        {
            case STATE.START:
                break;
            case STATE.MOVE:
                break;
            case STATE.GAMEOVER:
                //GUIにGame Overと表示する
                mText.text = "Game Over";
                //Scoreクラスからscoreを得る
                int score = Score.instance.score;
                //ハイスコアより現在スコアが高い時
                if (score > highScore)
                {
                    //ハイスコア更新
                    highScore = score;
                    //ハイスコアを保存
                    PlayerPrefs.SetInt(key[PlayerController.stageNo], highScore);
                    //ハイスコアを表示
                    highScoreText.text = "HighScore: " + highScore.ToString();
                }
                //もし、Jumpボタンが押されたら
                if (Input.GetButtonDown("Jump"))
                {
                    //今いるシーンをもう一度最初から呼び出す
                    SceneManager.LoadScene("Title");
                }
                break;
        }
    }

    IEnumerator StartCountDown()
    {
        //GUIの表示を3にする
        mText.text = "3";
        //1秒待つ
        yield return new WaitForSeconds(1.0f);
        //GUIの表示を3にする
        mText.text = "2";
        //1秒待つ
        yield return new WaitForSeconds(1.0f);
        //GUIの表示を3にする
        mText.text = "1";
        //1秒待つ
        yield return new WaitForSeconds(1.0f);
        //GUIに何も表示しない
        mText.text = "";
        //ゲームの状態をゲーム中にする
        state = STATE.MOVE;
    }
}