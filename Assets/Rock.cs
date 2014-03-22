using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	[SerializeField]
	private int _life;

	public GameObject gems;
	private GameObject managerGems;

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
			managerGems.GetComponent<ManagersGems>().createGems(gems, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		managerGems = GameObject.FindGameObjectWithTag ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		Die();
	}
}
