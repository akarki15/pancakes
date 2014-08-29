using UnityEngine;
using System.Collections;

public class userSettings : MonoBehaviour {
	public int lowerLimit;
	public int upperLimit;
	public int size;
	void Start () {
		lowerLimit = 1;
		upperLimit = 10;
		size =10;
		Object.DontDestroyOnLoad(this); 
	}
}
