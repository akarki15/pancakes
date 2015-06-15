	using UnityEngine;
	using System.Collections;

	public class buttonListener : MonoBehaviour {
		// General class attached to various buttons. Does different things based on which button this script is attached to.
		public GameObject userSettings;
			
		void OnMouseDown(){
			if (gameObject.tag.Equals ("quit")) {
			Debug.Log ("hi");
					Application.Quit ();			
			Debug.Log ("h1i");
				} else {
						if (gameObject.tag.Equals ("easy")) {
								userSettings.GetComponent<userSettings> ().lowerLimit = 1;	
								userSettings.GetComponent<userSettings> ().upperLimit = 10;
								userSettings.GetComponent<userSettings> ().size = 10;


						} else if (gameObject.tag.Equals ("medium")) {

								userSettings.GetComponent<userSettings> ().lowerLimit = 1;	
								userSettings.GetComponent<userSettings> ().upperLimit = 14;
								userSettings.GetComponent<userSettings> ().size = 12;

						} else if (gameObject.tag.Equals ("hard")) {

								userSettings.GetComponent<userSettings> ().lowerLimit = 1;	
								userSettings.GetComponent<userSettings> ().upperLimit = 18;
								userSettings.GetComponent<userSettings> ().size = 15;

						}	
						Application.LoadLevel ("game");
				}
		}
	}
