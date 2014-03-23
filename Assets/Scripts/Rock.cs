using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	enum Types {
		None,
		Rock_1,
		Rock_2,
		Rock_3,
		Rock_4, 
		Rock_5
	}

	[SerializeField]
	private Types _type = Types.None;

	[SerializeField]
	private int _life;
	public string type;

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
			for(int i = 0; i < 2; i++)
			{
				managerGems.GetComponent<ManagersGems>().createGems(gems, transform.position, Quaternion.identity);
			}
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
