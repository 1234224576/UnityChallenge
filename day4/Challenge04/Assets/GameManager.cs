using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	public GameObject unitychan;
	public GameObject zombi;
	public GameObject golden;
	public int score = 0;
	public bool isGameOver = false;

	//UIParts
	public GameObject scoreLabel;
	public GameObject gameOverLabel;
	public GameObject retryButton;


	// Use this for initialization
	void Start () {
		isGameOver = false;
		gameOverLabel.SetActive(false);
		retryButton.SetActive(false);
		StartCoroutine ("CreateCharactor");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScore(int val){
		if(!isGameOver) this.score += val;
		scoreLabel.GetComponent<Text>().text ="SCORE "+this.score;
	}

	public void gameOver(){
		isGameOver = true;
		gameOverLabel.SetActive(true);
		retryButton.SetActive(true);
	}

	private IEnumerator CreateCharactor(){
		Quaternion q = new Quaternion();
		q= Quaternion.identity;

		float x = Random.Range(-9.0f,9.0f);
		float y = 10.5f;
		float z = Random.Range(-4.0f,4.0f);
		Vector3 pos = new Vector3(x,y,z);

		int random = Random.Range(0,10);
		if(random==0){
			Instantiate(unitychan,pos,q);
		}else{
			Instantiate(zombi,pos,q);
		}
		random = Random.Range(0,30);
		if(random==1) Instantiate(golden,pos,q);
		yield return new WaitForSeconds (0.7f);
		if(!isGameOver){
			StartCoroutine ("CreateCharactor");
		}
	}
}
