using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour, IPlayer {

	private int _life = 100;
	
	public int Life {
		get {
			return this._life;
		}

		set {
			this._life = value;
		}
	}

	private float _speed = 2.0f;

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
		
	}
	
	void Update () {

	}

	void FixedUpdate () {
		this.Move();
	}

	public void Move () {
		this.transform.Translate(new Vector2(Input.GetAxis("Horizontal") * this._speed * Time.fixedDeltaTime, Input.GetAxis("Vertical") * this._speed * Time.fixedDeltaTime));

		if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") == 0) {

			this.GetComponent<SpriteRenderer>().sprite = this.sprites[2];

		} else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") == 0) {

			this.GetComponent<SpriteRenderer>().sprite = this.sprites[3];

		} else if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0) {

			this.GetComponent<SpriteRenderer>().sprite = this.sprites[1];

		} else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0) {

			this.GetComponent<SpriteRenderer>().sprite = this.sprites[0];

		} else {
			this.GetComponent<SpriteRenderer>().sprite = this.sprites[0];
		}
	}

	public void Attack () {

	}

	public void Die () {

	}
}
