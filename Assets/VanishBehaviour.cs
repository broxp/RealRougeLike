using UnityEngine;
using System.Collections;

public class VanishBehaviour : MonoBehaviour {
	float startTime = 4;
	float time;
	Vector3 initScale;
	public bool active = false;
	void Start () {
		initScale = gameObject.transform.localScale;
		time = startTime;
	}
	
	void Update () {
		if(!active){
			return;
		}
		time -= Time.deltaTime;
		//print(time);
		gameObject.transform.localScale = initScale * (time / startTime);
		if(time <= 0) {
			Destroy(gameObject);
		}
	}
}
