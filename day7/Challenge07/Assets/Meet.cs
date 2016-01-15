using UnityEngine;
using System.Collections;

public class Meet : MonoBehaviour {
	public GameObject smoke;
	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Floor"){
			GameObject obj = Instantiate(smoke,this.transform.position,Quaternion.identity) as GameObject;
			GameObject.Find("Pan").GetComponent<Pan>().gameover();
		}
	}
	// Update is called once per frame
	void Update () {
//		Vector3 move = new Vector3(0.0f,-1.0f*Time.deltaTime,0.0f);
//		transform.position += move;
	}
}
