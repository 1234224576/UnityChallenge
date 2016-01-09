using UnityEngine;
using System.Collections;

public class shot : MonoBehaviour {
	Vector3 center;
	public AudioClip showSE;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Confined; //はみ出さないモード
		Cursor.visible = false; //OSカーソル非表示
		center = new Vector3(Screen.width/2, Screen.height/2, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			fire();
			GetComponent<AudioSource>().PlayOneShot(showSE);
		}

	}

	private void fire(){
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(center);
		if(Physics.Raycast(ray,out hit,1000.0f)){
			GameObject hitObj = hit.collider.gameObject; 
			if(hitObj.tag =="enemy"){
				hitObj.GetComponent<zombi>().damege();
			}
			Debug.Log(hitObj.tag);
		}
	}
}
