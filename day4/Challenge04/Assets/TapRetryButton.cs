using UnityEngine;
using System.Collections;

public class TapRetryButton : MonoBehaviour {

	public void OnClick() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
