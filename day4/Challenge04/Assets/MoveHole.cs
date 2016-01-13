using UnityEngine;
using System.Collections;

public class MoveHole : MonoBehaviour {
	private Vector3 clickPosition;
	private Vector3 currentpos;
	void Start () {
		Cursor.lockState = CursorLockMode.Confined;
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "UnityChan"){
			GameObject.Find("GameManager").GetComponent<GameManager>().gameOver();
		}else if(other.gameObject.tag == "Zombi"){
			GameObject.Find("GameManager").GetComponent<GameManager>().addScore(10);
		}else if(other.gameObject.tag == "Gold"){
			GameObject.Find("GameManager").GetComponent<GameManager>().addScore(100);
		}

		Destroy(other.gameObject);
	}
	// Update is called once per frame
	void Update () {
		clickPosition = Input.mousePosition;
		clickPosition.z = 10f;
		Vector3 pos = Camera.main.ScreenToWorldPoint(clickPosition);
		pos.y = 0.45f;

		if(pos.x > 9.0f) pos.x = 9.0f;
		if(pos.z > 4.0f) pos.z = 4.0f;
		if(pos.x < -9.0f) pos.x = -9.0f;
		if(pos.z < -4.0f) pos.z = -4.0f;

		currentpos = pos;
		this.transform.position = Vector3.Lerp(this.transform.position,currentpos,0.2f);

	}

}
