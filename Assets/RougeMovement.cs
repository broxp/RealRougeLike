using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class RougeMovement : MonoBehaviour {
	public float speed = 1.5f;
	public float dist = 23f;
	public Transform target;
	Rigidbody rigidBody;
	Vector3 lastDir = new Vector3(1, 0, 0);
	Vector3 lastDir2 = new Vector3(1, 0, 0);
	Vector3 lastOrientation = new Vector3(1, 0, 0);

	Vector3 forward;
	GameObject[] arr = new GameObject[10];
	int arrInd = 0;
	void Start() {
		rigidBody = GetComponent<Rigidbody>();
	}

	void Update () {
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");
		forward = new Vector3(h, 0, v);
		print(forward);
		var orientation = new Vector3(h, v, 0);
		if(forward != Vector3.zero) {
			lastDir = forward;
			if(lastDir.x * lastDir.x + lastDir.z * lastDir.z > 0.01) {
				lastDir2 = lastDir;
				lastOrientation = orientation;
			}
		}
		var deltaPos = speed * forward;
		var isJump = Input.GetButton("Jump");
		/*if(lastDir.x * lastDir.x < 0.0001f) {
			lastDir.x = 0.00001f * Mathf.Sign(lastDir.x);
		}*/
		Quaternion	rotation = Quaternion.LookRotation(lastDir2);
		transform.rotation = rotation;
		//transform.position += deltaPos;


		if(isJump) {
			var old = arr[arrInd];
			if(old != null){
				Destroy(old);
			}
			var spawnPos =  lastDir2 * dist + gameObject.transform.position + new Vector3(2 * Random.value - 1, 0, 2 * Random.value - 1);
			spawnPos.y = 0;
			arr[arrInd] = (GameObject) Instantiate(target.gameObject, spawnPos, target.rotation);
			arr[arrInd].GetComponent<VanishBehaviour>().active = true;
			arrInd = (arrInd + 1) % arr.Length;
		}
	}
	void FixedUpdate() {
		if(forward != Vector3.zero) {
			rigidBody.AddForce(speed * forward);
		}
	}
}
