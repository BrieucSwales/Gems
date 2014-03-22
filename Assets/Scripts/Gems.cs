using UnityEngine;
using System.Collections;

public class Gems : MonoBehaviour {

	public event System.Action<GameObject> onDestroy;

	//private AnimationCurve movementBounce;


	// Use this for initialization
	void Awake () {

	}
	
	void Collected() {
		onDestroy( gameObject );
		Destroy(this.gameObject);
	}

}
