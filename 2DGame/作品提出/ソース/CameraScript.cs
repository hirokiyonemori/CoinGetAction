using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    public GameObject player;
    public GameObject step;
    //********** 開始 **********//
    public GameObject wall;
    //********** 終了 **********//
    public Text scoreText;
    public Text highScoreText;
    //public GameOverScript gameOverScript;
    private int score = 0;
    private int scoreUpPos = 3;
    //********** 開始 **********//
    private int createWallPos = 10;
    //********** 終了 **********//
    private Transform playerTrans;
    private int highScore;
    private string key = "HIGH SCORE";

    void Start()
    {
        playerTrans = player.GetComponent<Transform>();
        scoreText.text = "Score: 0";
        highScore = PlayerPrefs.GetInt(key, 0);
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    void Update()
    {
        float playerHeight = playerTrans.position.y;
        float currentCameraHeight = transform.position.y;
        float newHeight = Mathf.Lerp(currentCameraHeight, playerHeight, 0.5f);
        if (playerHeight > currentCameraHeight)
        {
            transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
        }

        if (playerTrans.position.y >= scoreUpPos)
        {
            scoreUpPos += 3;
            score += 10;
            scoreText.text = "Score: " + score.ToString();
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt(key, highScore);
                highScoreText.text = "HighScore: " + highScore.ToString();
            }
            CreateStep();
        }
        //********** 開始 **********//
        if (playerTrans.position.y >= createWallPos)
        {
            CreateWall();
            createWallPos += 10;
        }
        //********** 終了 **********//
        if (playerTrans.position.y <= currentCameraHeight - 6)
        {

           // gameOverScript.Lose();

            Destroy(player);
        }
    }

    void CreateStep()
    {
        Instantiate(step, new Vector2(Random.Range(-6.0f, 0f), scoreUpPos + Random.Range(4.0f, 6.0f)), step.transform.rotation);
        Instantiate(step, new Vector2(Random.Range(0f, 6.0f), scoreUpPos + Random.Range(4.0f, 6.0f)), step.transform.rotation);
    }
    //********** 開始 **********//
    void CreateWall()
    {
        //左右にひとつずつ壁を作成
        Instantiate(wall, new Vector2(8f, createWallPos + 10), wall.transform.rotation);
        Instantiate(wall, new Vector2(-8f, createWallPos + 10), wall.transform.rotation);
    }
    //********** 終了 **********//
}