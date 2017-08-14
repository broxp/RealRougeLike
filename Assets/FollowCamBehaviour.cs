using UnityEngine;
using System.Collections;

public class FollowCamBehaviour : MonoBehaviour {
	public Transform target;
	
	void Update () {
		var pos = target.position;
		pos.y = gameObject.transform.position.y;
		transform.position = pos;
	}
}
