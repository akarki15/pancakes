using UnityEngine;
using System.Collections;

public class GamePlay : MonoBehaviour {

	// Use this for initialization
	public int upperLimit;
	public int lowerLimit;
	public int size;
	// pancakes stores size, cakes stores gameobject
	public GameObject[]cakes;
	private GameObject userSettings;

	private bool won;
	void Start () {
		userSettings = GameObject.FindGameObjectsWithTag ("userSettings")[0];
		size = userSettings.GetComponent<userSettings>().size;
		upperLimit = userSettings.GetComponent<userSettings>().upperLimit;
		lowerLimit = userSettings.GetComponent<userSettings>().lowerLimit;
		cakes = new GameObject[size];
		won = false;	
		draw ();
	}


	public GameObject prefab;
	public GameObject anim;

	// Create the pancakes and give them size
	void draw(){
		for (int i=0;i<size;i++){
			Vector3 pos=new Vector3(0,-i*2F,0);
			cakes[i]=Instantiate(prefab, pos,Quaternion.identity) as GameObject;
			int tempSize = cakes[i].GetComponent<PanProperties>().size = (int) Random.Range(lowerLimit,upperLimit);		
			cakes[i].transform.localScale+=new Vector3(1F*(tempSize-1),0,0);
			cakes[i].GetComponent<PanProperties>().position=i;
		}
	}


	// Handles Animations for flip	
	public void flip(int i){
		for (int counter =0; counter<=i; counter++) {
			Vector3 position = new Vector3 (0, -(i-counter)*2, 0);
			cakes [counter].GetComponent<PanProperties> ().animate (position);
			cakes [counter].GetComponent<PanProperties> ().position = i - counter; 		
		}

		// Update cakes[]
		for (int counter =0; counter<=(i/2); counter++)
					swap (counter, i-counter);
		won=check();
		if (won) {
			print ("A");
			StartCoroutine(wait(5.0F));
			print ("B");
			Application.LoadLevel("winscene");
					
		}
	}

	bool check(){
		bool w = true;
		for (int counter =1; counter<size; counter++)
						w = w && (cakes [counter].GetComponent<PanProperties> ().size >= cakes [counter - 1].GetComponent<PanProperties> ().size);
		return w;
	}
	//swap to keep cakes[] up to date
	void swap(int i, int j){
		GameObject temp = cakes [i];
		cakes [i] = cakes [j];
		cakes [j] = temp;
	}
	// This coroutine lets the animation finish before changing the scene 
	IEnumerator wait(float waitTime){
		yield return new WaitForSeconds (waitTime);
	}	
}	
