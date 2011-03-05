using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;
	
	private Transform myTransform;
	
	void Awake() {
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		target = go.transform;
		
		maxDistance = 2;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(target.position, myTransform.position, Color.yellow);
		
		//Look at target also includes time.deltatime which scales the speed on all systems. So they will all have the exact same move speed even if your computer sucks.
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		
		if(Vector3.Distance(target.position, myTransform.position) > maxDistance) {
			//Move towars target
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		
	}
}
