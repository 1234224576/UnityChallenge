using UnityEngine;
using System.Collections;

public class GameOverJudge : MonoBehaviour {

	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.tag == "Player"){
			Debug.Log("ゲームオーバー");
			GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver = true;
		}
		Destroy(collision.gameObject);
	}
}
