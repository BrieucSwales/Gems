using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rock : MonoBehaviour {

	[SerializeField]
	private int _life;

	public List<Sprite> spritesRock;
	
	public GameObject gems;
	private GameObject _managerGems;

	public int nbrGems;

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
		ChangeSprite();
	}

	void ChangeSprite()
	{
		if(this.name == "Rock_1"){
			if(this._life == 1)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[Random.Range(2, 4)];
			if(this._life == 0)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[Random.Range(4, 7)];
		}

		if(this.name == "Rock_2"){
			if(this._life == 2)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[Random.Range(2, 3)];
			if(this._life == 1)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[Random.Range(3, 5)];
			if(this._life == 0)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[Random.Range(5, 7)];
		}

		if(this.name == "Rock_3"){
			if(this._life == 3)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[Random.Range(2, 3)];
			if(this._life == 2)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[Random.Range(3, 4)];
			if(this._life == 1)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[Random.Range(4, 5)];
			if(this._life == 0)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[Random.Range(5, 7)];

		}

		if(this.name == "Rock_4"){
			if(this._life == 5)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[1];
			if(this._life == 4)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[2];
			if(this._life == 3)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[3];
			if(this._life == 2)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[4];
			if(this._life == 1)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[5];
			if(this._life == 0)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[6];
		}

		if(this.name == "Rock_5"){
			if(this._life == 5)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[1];
			if(this._life == 4)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[2];
			if(this._life == 3)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[3];
			if(this._life == 2)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[4];
			if(this._life == 1)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[5];
			if(this._life == 0)
				this.GetComponent<SpriteRenderer>().sprite = spritesRock[6];
		}
	}
	
	void Die () {
		if(_life <= 0) {
			for(int i = 0; i < nbrGems; i++){
				_managerGems.GetComponent<ManagersGems>().createGems(gems, transform.position, Quaternion.identity);
			}
			Destroy(this.gameObject);
		}
	}

	void Awake() {

	}
	void Start () {
		_managerGems = GameObject.FindGameObjectWithTag ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		Die();
	}
}
