using UnityEngine;
using System.Collections;

public class Game_Manager : MonoBehaviour {
	
	private static Game_Manager instance;

	private int _score = 0;

	public int Score {
		get {
			return this._score;
		}
		set {
			this._score = value;
		}
	}

	private int _timeLeft = 0;

	public int TimeLeft {
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
}
