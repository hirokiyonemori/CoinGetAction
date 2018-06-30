using UnityEngine;
using System.Collections;

public class createScript : MonoBehaviour {
	public GameObject enemy1;
	public GameObject block;
	int enemyBorder  = 0;
	int time = 0;
    int Level = 0;
	void Update ()
	{
		time++;


		//時間で敵を生成する。
//if (time > 120 -(Level )) {
//	CreateEnemy ();
//	time = 0;
//     Level++;
//
// }


    }
	void CreateEnemy (){
		
		//Instantiate (enemy1, new Vector3 (10, Random.Range(-3, 1), 0), enemy1.transform.rotation);

		//enemyBorder += 80;
	}
}
