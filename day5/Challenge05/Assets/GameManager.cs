using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject scoreLabel;
	public GameObject gameoverLabel;
	public GameObject restartButton;

	public GameObject charPrefab;
	GameObject currentChar;
	bool isGameOver = false;
	int score = 1;

	// Use this for initialization
	void Start () {
		gameoverLabel.SetActive(false);
		restartButton.SetActive(false);
		score = 1;
		scoreLabel.GetComponent<Text>().text = "SCORE "+score;
		isGameOver = false;
		StartCoroutine("makeChar");
	}
	
	// Update is called once per frame
	void Update () {
		currentChar.transform.position += new Vector3(Input.GetAxis("Horizontal")*0.1f,0,0);
	}

	public void gameover(){
		isGameOver = true;
		gameoverLabel.SetActive(true);
		restartButton.SetActive(true);

	}

	private IEnumerator makeChar(){

		Vector3 pos = new Vector3(Random.Range(-1.2f,1.0f),5.0f,-0.5f);
		currentChar = Instantiate(charPrefab,pos, Quaternion.Euler(270, 180, 0)) as GameObject;
		yield return new WaitForSeconds (10.0f);
		if(!isGameOver){
			score++;
			scoreLabel.GetComponent<Text>().text = "SCORE "+score;
			StartCoroutine("makeChar");
		}
	}
}
