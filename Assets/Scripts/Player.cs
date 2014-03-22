using UnityEngine;
using System.Collections;

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

	private float _speed = 5.0f;

	public float Speed {
		get {
			return this._speed;
		}

		set {
			this._speed = value;
		}
	}

	void Start () {
		
	}
	
	void Update () {
		this.Move();
	}

	public void Move () {
		this.transform.Translate(new Vector2(Input.GetAxis("Horizontal") * this._speed * Time.deltaTime, Input.GetAxis("Vertical") * this._speed * Time.deltaTime));
	}

	public void Attack () {

	}

	public void Die () {

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Rock"){
			Debug.Log ("It's colliding");
		}
		
	}
}
