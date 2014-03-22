using UnityEngine;
using System.Collections;

public class Gems : MonoBehaviour {

	public event System.Action<GameObject> onDestroy;

	[SerializeField]
	private AnimationCurve _curve;
	//private AnimationCurve movementBounce;


	// Use this for initialization
	void Start () {
	
	}
	
	void Collected() {
		onDestroy( gameObject );
		Destroy(this.gameObject);
	}

}
