using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour {

	float currentPosZ = 0.0f;
	float moveAmount = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorStateInfo stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
		if(stateInfo.IsName("Base Layer.Jump")){
			return;
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
			StartCoroutine("move",true);
		}else if(Input.GetKeyDown(KeyCode.LeftArrow)){
			StartCoroutine("move",false);
		}else if(Input.GetKeyDown(KeyCode.UpArrow) ){
			GetComponent<Rigidbody>().AddForce(Vector3.up * 12000);
			GetComponent<Animator>().SetTrigger("Jump");
		}

	}
	private IEnumerator move(bool isRight) {
		if(isRight){
			currentPosZ += 0.2f;
		}else{
			currentPosZ -= 0.2f;
		}
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, currentPosZ);
		yield return new WaitForSeconds (0.01f);

		if(currentPosZ >= 2.9f || currentPosZ <= -2.9f ||(currentPosZ >= -0.1f && currentPosZ <= 0.1f)){

		}else{
			StartCoroutine("move",isRight);
		}
	}

}
