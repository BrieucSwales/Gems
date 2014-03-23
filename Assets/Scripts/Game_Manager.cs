using UnityEngine;
using System.Collections;

public class Game_Manager : SingleBehaviour<Game_Manager> {

	[SerializeField]
	private int _score = 0;

	[SerializeField]
	private int _scorePlayer2 = 0;

	[SerializeField]
	UILabel _timeLeftLabel;

	public int Score {
		get;
		set;
	}

	public int ScorePlayer2 {
		get;
		set;
	}

	public float TimeLeft {
		get;
		set;
	}

	private Game_Manager () {}

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	void Update () {
		this.TimeLeft += Time.deltaTime;
		this._timeLeftLabel.text = Mathf.Floor(this.TimeLeft).ToString();
	}
}
