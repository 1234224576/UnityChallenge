using UnityEngine;
using System.Collections;

public class TextMove : MonoBehaviour {
	public string showText = "Hello!!";

	// Use this for initialization
	void Start () {
		this.GetComponent<TextMesh>().text = this.showText;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3 (1.2f, 0,0);
	}
}
