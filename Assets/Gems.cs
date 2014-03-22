using UnityEngine;
using System.Collections;

public class Gems : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void Collected() {
		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
