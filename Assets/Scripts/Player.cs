using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour, IPlayer {

	private int _life = 100;
	private bool _canMine = false;

	// GameObjects
	public GameObject rocks;
	private GameObject _RockObject;

	// INTERFACE 
	private int _score;

	private Animator _animator;


	public int Life {
		get {
			return this._life;
		}

		set {
			this._life = value;
		}
	}

	private float _speed = 1.5f;

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
		this._animator = this.GetComponent<Animator>();
	}
	
	void Update () {
		Mining();
	}

	void FixedUpdate () {
		this.Move();
	}

	public void Move () {

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		this.transform.Translate(new Vector2(horizontal * this._speed * Time.fixedDeltaTime, vertical * this._speed * Time.fixedDeltaTime));
	

		if (horizontal > 0) {

			this._animator.SetInteger("Direction", 2);

		} else if (horizontal < 0) {

			this._animator.SetInteger("Direction", 1);

		} else if (vertical > 0) {

			this._animator.SetInteger("Direction", 3);

		} else if (vertical < 0) {

			this._animator.SetInteger("Direction", 4);

		} else {

			this._animator.SetInteger("Direction", 0);

		}
	}

	void OnCollisionEnter2D(Collision2D collision) {

		if(collision.gameObject.tag == "Rock"){
			_canMine = true;
			_RockObject = collision.gameObject;
		}

		if(collision.gameObject.tag == "Gem"){
			_score += 10;
			Collecting(collision.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D collisionInfo) {
		if(collisionInfo.gameObject.tag == "Rock"){
			_canMine = false;
		}
	}

	void Mining() {
		if (Input.GetKeyDown("space"))
			if(_canMine && _RockObject != null){
				_RockObject.SendMessage("TakeDamage", 1);
			}
	}

	void Collecting(GameObject Gems) {
		Gems.SendMessage("Collected");
	}

	public void Attack () {

	}

	public void Die () {

	}

}
