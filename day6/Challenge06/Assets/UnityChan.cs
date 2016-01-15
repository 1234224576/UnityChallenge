using UnityEngine;
using System.Collections;

public class UnityChan : MonoBehaviour {
	GameObject parent;
	// Use this for initialization
	void Start () {
		parent = GameObject.Find("attackBot");
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += new Vector3(2.0f*Time.deltaTime,0.0f,0.0f);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name != "Floor" && col.gameObject.name !="attackBot"){
			Destroy(this.gameObject);
		}
	}
}
