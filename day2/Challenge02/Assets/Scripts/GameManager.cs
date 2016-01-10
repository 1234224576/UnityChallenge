using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject[] objects;
	public GameObject meterText;
	public GameObject scrollText;
	int score = 0;
	public bool isGameOver = false;
	// Use this for initialization
	void Start () {
		StartCoroutine("make");
		StartCoroutine("counter");
		createText("GAME START!");
	}
	
	// Update is called once per frame
	void Update () {
		if(!isGameOver){
			meterText.GetComponent<TextMesh>().text = score +"m";
		}

	}

	private IEnumerator counter(){
		score++;
		if(score % 1000 == 0){
			createText("Marvelous! OVER "+score +"m");
		}else if(score % 100 == 0){
			createText("Great! OVER "+score +"m");
		}else{
			int rand = Random.Range(0,500);
			if(rand == 10){
				createText("GO GO GO!");
			}else if(rand == 20){
				createText("Nice Play!");
			}else if(rand == 30){
				createText("Hello!Unity World!");
			}
		}
		yield return new WaitForSeconds (0.333f);
		if(!isGameOver){
			StartCoroutine("counter");
		}else{
			createText("GAME OVER...    SCORE "+score+"m");
			yield return new WaitForSeconds (5.0f);
			Application.LoadLevel("title");
		}
	}


	private IEnumerator make() {
		int rand = Random.Range (0,2);
		Debug.Log(rand);
		GameObject obj = objects[rand];
		float pos = -3.0f + 3.0f * Random.Range (0,3);
		Instantiate(obj, new Vector3(-150.0f, 20.0f, pos), Quaternion.identity);
		float interval = Random.Range (0.3f,3.0f);
		yield return new WaitForSeconds (interval);
		StartCoroutine("make");
	}

	void createText(string text){
		scrollText.GetComponent<TextMove>().showText = text;
		Instantiate(scrollText, new Vector3(-250.0f, 20.0f, -50.0f),  Quaternion.Euler(new Vector3(0,-180.0f,0)));
	}
}
