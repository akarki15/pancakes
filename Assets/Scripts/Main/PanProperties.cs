using UnityEngine;
using System.Collections;

public class PanProperties : MonoBehaviour {
	public int position;
	public int size;
	GameObject init;

	bool trigger;

	Vector3 startMarker;	
	Vector3 endMarker;
	public float speed;
	private float startTime;
	private float journeyLength;
	public float smooth ;
	// Use this for initialization
	void Start () {
		init =  GameObject.FindGameObjectsWithTag("init")[0];
		trigger = false;
		speed = 30.0F;
		smooth = 20.0F;
		startMarker = endMarker = gameObject.transform.position;
		// Initializing to prevent error since update runs all the time
	}
	void OnMouseDown(){
		init.GetComponent<GamePlay>().flip (position);
	}

	public void animate(Vector3 end){
		Debug.Log ("target is " + end);
		startMarker = gameObject.transform.position;
		endMarker = end;
		startTime = Time.time;
		journeyLength=Vector3.Distance(startMarker,endMarker);

	}
	void LateUpdate() {
			if (startMarker != endMarker) {
						float distCovered = (Time.time - startTime) * speed;
						float fracJourney = distCovered / journeyLength;			
						transform.position = Vector3.Lerp (startMarker, endMarker, fracJourney);
				}
			
	}
}
