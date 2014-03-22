using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour, IPlayer {

	private int _life = 100;
	private bool _canMine = false;
	public GameObject rocks;
	private Rock _RockObject;


	public int Life {
		get {
			return this._life;
		}

		set {
			this._life = value;
		}
	}

	private float _speed = 5.0f;

	public float Speed {
		get {
			return this._speed;
		}

		set {
			this._speed = value;
		}
	}

	public List<Sprite> sprites;

	void Start () {
		_RockObject = rocks.GetComponent<Rock>();
	}
	
	void Update () {
		Mining();

	}

	void FixedUpdate () {
		this.Move();
	}

	public void Move () {
		this.transform.Translate(new Vector2(Input.GetAxis("Horizontal") * this._speed * Time.fixedDeltaTime, Input.GetAxis("Vertical") * this._speed * Time.fixedDeltaTime));

		if (Input.GetAxis("Horizontal") > 0) {

			this.GetComponent<SpriteRenderer>().sprite = this.sprites[2];

		} else if (Input.GetAxis("Horizontal") < 0) {

			this.GetComponent<SpriteRenderer>().sprite = this.sprites[3];

		} else if (Input.GetAxis("Vertical") > 0) {

			this.GetComponent<SpriteRenderer>().sprite = this.sprites[1];

		} else if (Input.GetAxis("Vertical") < 0) {

			this.GetComponent<SpriteRenderer>().sprite = this.sprites[0];

		} else {
			this.GetComponent<SpriteRenderer>().sprite = this.sprites[0];
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "Rock")
			_canMine = true;
	}

	void Mining() {
		if (Input.GetKeyDown("space"))
			if(_canMine){
				_canMine = false;
				_RockObject.SendMessage("TakeDamage", 1);
			}

	}

	public void Attack () {

	}

	public void Die () {

	}

}
