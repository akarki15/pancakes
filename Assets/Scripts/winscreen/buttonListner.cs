using UnityEngine;
using System.Collections;

public class buttonListner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Destroy (GameObject.FindGameObjectsWithTag("userSettings")[0]);
		Application.LoadLevel("welcome");
	}
}
