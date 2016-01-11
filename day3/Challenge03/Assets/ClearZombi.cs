using UnityEngine;
using System.Collections;

public class ClearZombi : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Player"){
			Application.LoadLevel("title");

		}
	}
}
