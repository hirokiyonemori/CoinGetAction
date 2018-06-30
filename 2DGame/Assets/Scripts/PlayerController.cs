using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//AudioSourceを必要とする
//これを記述しておくとこのコンポーネントを追加した際に
//一緒にAudioSorceコンポーネントも追加される
[RequireComponent(typeof(AudioSource))]

/*
 * Playerクラス
 * 
 * UnityChan2DController以外のことを制御する
 * 
 */
public class PlayerController : MonoBehaviour
{


    public AudioClip jumpVoice;     //ジャンプした時の声
    public AudioClip damageVoice;   //ダメージを受けた時雄の声
    public static byte stageNo = 0; //選択したstage番号
    private AudioSource mAudio;     //AudioSource
    private UnityChan2DController mUnityChan2DController; //UnityChan2DController
    private Collider2D mCollider2D;

    /*
	 * はじめに呼ばれる関数
	 */
    void Start()
    {
        //必要なコンポーネントを取得する
        mAudio = GetComponent<AudioSource>();
        mUnityChan2DController = GetComponent<UnityChan2DController>();
        mCollider2D = GetComponent<Collider2D>();
    }

    /*
	 * ダメージを受けた時に呼ばれる関数
	 */
    void OnDamage()
    {
        //声を出す
        PlayerVoice(damageVoice);

        //当たりをなくす
        mCollider2D.enabled = false;
        //動けなくする
        mUnityChan2DController.enabled = false;
        //ゲーム遷移をゲームオーバーにする
        Game.instance.state = Game.STATE.GAMEOVER;
    }

    void Jump()
    {
        //声を出す
        PlayerVoice(jumpVoice);
    }

    void PlayerVoice(AudioClip clip)
    {
        //音を消す
        mAudio.Stop();
        //音を再生する
        mAudio.PlayOneShot(clip);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        //シーン切り替え
        if (c.tag == "Stage1")
        {
            SceneManager.LoadScene("2Dgame");
            stageNo = 0;
        }
        //Stage2
        if (c.tag == "Stage2")
        {
            SceneManager.LoadScene("stage2");
            stageNo = 1;
        }
        //Stage3
        if (c.tag == "Stage3")
        {
            SceneManager.LoadScene("stage3");
            stageNo = 2;
        }
        //ゲームスタート
        if (c.tag == "GameStart")
        {
            SceneManager.LoadScene("StageSelect");
        }
        //ゲーム終了
        if (c.tag == "End")
        {
            Application.Quit();
        }
        
    }
}
