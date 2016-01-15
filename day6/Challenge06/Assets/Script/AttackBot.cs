using UnityEngine;
using System.Collections;

public class AttackBot : MonoBehaviour {

	CharacterController controller;
	Vector3 moveDirection = Vector3.zero;

	int score = 0;

	public GameObject bullet;

	public float gravity;
	public float speedX;
//	public GameObject camera;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();	
	}

	void OnControllerColliderHit(ControllerColliderHit col){
		Debug.Log(col.gameObject.name);
		if(col.gameObject.tag == "Core"){
			score++;
			Destroy(col.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		if(score==5){
			Application.LoadLevel("main");
		}
		if(controller.isGrounded){
			moveDirection.x = Input.GetAxis("Vertical") * speedX;
			transform.Rotate(0,Input.GetAxis("Horizontal")*3,0);
		}
		moveDirection.y -= gravity*Time.deltaTime;
		Vector3 globalDirection = transform.TransformDirection(moveDirection);
		controller.Move(globalDirection * Time.deltaTime);
		if(controller.isGrounded) moveDirection.y = 0;

		if(Input.GetButtonDown ("Jump")){
			GameObject shell = Instantiate(bullet,transform.position,Quaternion.Euler(0.0f,90.0f,0.0f)) as GameObject;


			Vector3 centerPos = Vector3.up;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(centerPos);
			shell.GetComponent<Rigidbody>().AddForce(globalDirection*1000.0f);

		}
	}
}
