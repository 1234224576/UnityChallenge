using UnityEngine;
using System.Collections;

public class zombi : MonoBehaviour {
	Animator animator;
	GameObject Player;
	int hp = 4;
	float speed =  Random.Range(5.0f, 14.0f);
	// Use this for initialization
	void Start () {
		Player = GameObject.Find("/Player");
		animator = GetComponent<Animator>();
		animator.SetTrigger("attack");
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat("speed",10);

		Vector3 pos = Player.transform.position;
		Vector3 direction = pos - transform.position;

		if(Mathf.Abs(direction.x) > 3.0|| Mathf.Abs(direction.z) > 3.0){
			direction = direction.normalized;
			transform.position = transform.position + (direction * speed * Time.deltaTime);
			transform.position = new Vector3(transform.position.x,1,transform.position.z);
			transform.LookAt(Player.transform);
		}else{
			animator.SetTrigger("attack");
		}
	}

	void OnCollisionEnter(Collision col){
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if(col.gameObject.tag == "Player" && stateInfo.nameHash ==  Animator.StringToHash("Base Layer.attack")){
			Application.LoadLevel("title");
		}
	}

	public void damege(){
		hp--;
		if(hp<=0){
			Destroy(this.gameObject);
		}
	}
}
