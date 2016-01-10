using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3 (0.2f, 0, 0);
	}
}
