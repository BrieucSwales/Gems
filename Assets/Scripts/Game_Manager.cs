using UnityEngine;
using System.Collections;

public class Game_Manager : SingleBehaviour<Game_Manager> {

<<<<<<< HEAD
	[SerializeField]
	private int _score = 0;

=======
>>>>>>> faf2b552455d361508562bc5c606187d4e8805e3
	[SerializeField]
	UILabel _timeLeftLabel;

	public int Score {
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
