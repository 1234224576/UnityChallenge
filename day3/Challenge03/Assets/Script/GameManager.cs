using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class GameManager : MonoBehaviour {
	//GameObject
	public GameObject keyText;

	//Parameter
	public int keynum = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 center = new Vector3(Screen.width/2, Screen.height/2, 0);
			Ray ray = Camera.main.ScreenPointToRay(center);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit, 10)) {
				clickEvent(hit.collider.gameObject);
			}
		}
	}

	void clickEvent(GameObject obj){
		if(obj.tag == "Key"){
			getKey();
			updateTextLabel();
			Destroy(obj);
		}
		if(obj.tag == "Door"){
			if(isUseKey()){
				Destroy(obj);
				updateTextLabel();
			}
		}
	}

	public void updateTextLabel(){
		keyText.GetComponent<Text>().text = "Key :" + keynum;
	}
	public void getKey(){
		keynum++;
	}
	public bool isUseKey(){
		if(keynum > 0){
			keynum--;
			return true;
		}else{
			return false;
		}
	}
}
