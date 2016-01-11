using UnityEngine;
using System.Collections;

public class MyButton : MonoBehaviour {

	// Use this for initialization
	public void OnClick() {
		Application.LoadLevel("TestMap");
	}
}
