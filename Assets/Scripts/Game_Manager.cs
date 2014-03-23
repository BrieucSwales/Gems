using UnityEngine;
using System.Collections;

public class Game_Manager : MonoBehaviour {
	
	private static Game_Manager instance;

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
	
	public static Game_Manager Instance {
		get {
			if (instance == null) {
				instance = new Game_Manager();
			}
			
			return instance;
		}
	}

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	void Update () {
		this._timeLeft += Time.deltaTime;
		this._timeLeftLabel.text = Mathf.Floor(this._timeLeft).ToString();
	}
}
