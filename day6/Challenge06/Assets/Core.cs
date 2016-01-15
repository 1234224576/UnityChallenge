using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("move");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private IEnumerator move(){
		float x = Random.Range(-10000.0f,10000.0f);
		GetComponent<Rigidbody>().AddForce(x,10000.0f,x);
		yield return new WaitForSeconds(5.0f);
		StartCoroutine("move");
	}
}
