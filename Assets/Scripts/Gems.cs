using UnityEngine;
using System.Collections;

public class Gems : MonoBehaviour {

	public event System.Action<GameObject> onDestroy;

	// Use this for initialization
	void Start () {
	
	}

	void Collected() {
		onDestroy( gameObject );
		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
