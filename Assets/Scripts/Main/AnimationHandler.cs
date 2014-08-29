using UnityEngine;
using System.Collections;

public class AnimationHandler:MonoBehaviour {
	// This class takes a gameobject and animates it from startMarker to endMarker


	// Use this for initialization

	Transform startMarker;	
	Transform endMarker;
	public float speed;
	private float startTime;
	private float journeyLength;
	public Transform target;
	public float smooth ;
	bool trigger=false;
	void start(){

	}
	// TODO Find a way to properly initialize these values. Update() might get called before init();
	public void initialize (GameObject p, Transform s, Transform e, float sp, float sm) {
		Debug.Log ("new animation "+ s.position +"    "+e.position);
		target = p.transform;
		startMarker = s;
		endMarker = e;
		speed = sp;
		smooth = sm;
		startTime = Time.time;
		trigger = true;
	}
	
	void Update() {
		if (trigger) {
			Debug.Log("Objects: "+ startMarker+" "+endMarker);
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			target.position = Vector3.Lerp (startMarker.position, endMarker.position, fracJourney);
			if (fracJourney == 0) {
					Destroy (gameObject);		
			}
		}
	}
}
