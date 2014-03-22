using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	[SerializeField]
	private int _life;

	public GameObject gems;

	public int Life {
		get {
			return this._life;
		}
		
		set {
			this._life = value;
		}
	}

	void TakeDamage (int amout)
	{
		this._life -= amout;
	}
	
	void Die () {
		if(_life <= 0) {
			instantiateGems();
			Destroy(this.gameObject);
		}
	}

	void instantiateGems()
	{
		GameObject Gems = Instantiate(gems, transform.position, transform.rotation) as GameObject;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Die();
	}
}
