using UnityEngine;
using System.Collections;

public class isu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Floor") GameObject.Find("GameManager").GetComponent<GameManager>().gameover();
	}
}
