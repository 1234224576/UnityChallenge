using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Pan : MonoBehaviour {
	int score = 0;

	bool isGameOver = false;

	public GameObject scoreLabel;
	public GameObject retryButton;
	public GameObject gameOverLabel;
	// Use this for initialization
	void Start () {
		retryButton.SetActive(false);
		gameOverLabel.SetActive(false);
	}
	void OnCollisionEnter(Collision col){
		if(!isGameOver){
			float randForce = Random.Range(0.0f,100.0f);
			col.gameObject.GetComponent<Rigidbody>().AddForce(0.0f,200.0f+randForce,0.0f);
			score++;
			Physics.gravity += new Vector3(0f, 0f, -0.02f);
			scoreLabel.GetComponent<Text>().text = "SCORE "+score;
		}
	}
	void Update () {
		Vector3 move = new Vector3(Input.GetAxis("Horizontal")*0.2f,0.0f,0.0f);
		transform.position += move;
	}
	public void gameover(){
		isGameOver = true;
		retryButton.SetActive(true);
		gameOverLabel.SetActive(true);
	}

}
