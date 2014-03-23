using UnityEngine;
using System.Collections;

public class Game_Manager : SingleBehaviour<Game_Manager> {

	[SerializeField]
	private int _score = 0;

	[SerializeField]
	UILabel _timeLeftLabel;

	public int Score {
		get {
			return this._score;
		}
		set {
			this._score = value;
		}
	}

	private float _timeLeft = 0;

	public float TimeLeft {
		get {
			return this._timeLeft;
		}
		set {
			this._timeLeft = value;
		}
	}

	private Game_Manager () {}

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	void Update () {
		this._timeLeft += Time.deltaTime;
		this._timeLeftLabel.text = Mathf.Floor(this._timeLeft).ToString();
	}
}
