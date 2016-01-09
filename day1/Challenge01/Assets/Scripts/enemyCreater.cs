using UnityEngine;
using System.Collections;

public class enemyCreater : MonoBehaviour {

	public GameObject prefab;
	int index = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine ("create");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator create() {

		float offsetX = Random.Range(0.0f,200.0f);
		float offsetZ = Random.Range(0.0f,200.0f);
		Vector3 pos = new Vector3(offsetX,1.0f,offsetZ);
		Instantiate(prefab,pos,transform.rotation);
		yield return new WaitForSeconds (1f);
		index++;
		if(index<200){
			StartCoroutine ("create");
		}

	}
}