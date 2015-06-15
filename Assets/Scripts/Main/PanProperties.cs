using UnityEngine;
using System.Collections;

public class PanProperties : MonoBehaviour {
	// PanProperties class is attached to each pancake model; it stores the pancake's properties and handles mouse events 
	
	public int position;	// Position of the pancake on the screen
	public int size;		// Length of the pancake
	GameObject init;		// Just a referenece to the empty model to which the GamePlay script is attached 

	// Variables needed for animating the pancake
	Vector3 startMarker;	
	Vector3 endMarker;
	public float speed;
	private float startTime;
	private float journeyLength;
	public float smooth ;

	// Initialization
	void Start () {
		init =  GameObject.FindGameObjectsWithTag("init")[0];
		// Hardcode the speed and smooth of animation
		speed = 30.0F;
		smooth = 20.0F;
		// Initializing to prevent error since update runs all the time
		startMarker = endMarker = gameObject.transform.position;

	}

	// Flip the cakes when this pancake is touched
	void OnMouseDown(){
		init.GetComponent<GamePlay>().flip (position);
	}

	// Animate this pancake from position startMarker to endMarker
	public void animate(Vector3 end){
		startMarker = gameObject.transform.position;
		endMarker = end;
		startTime = Time.time;
		journeyLength=Vector3.Distance(startMarker,endMarker);
	}

	// This thred runs all the time and results in an animation when startMarker and endMarker positions differ
	void LateUpdate() {
		if (startMarker != endMarker) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;			
			transform.position = Vector3.Lerp (startMarker, endMarker, fracJourney);
		}
	}
}
