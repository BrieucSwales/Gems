using UnityEngine;
using System.Collections;

public class Game_Manager : MonoBehaviour {
	
	private static Game_Manager instance;

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
		this.TimeLeft += Time.deltaTime;
		this._timeLeftLabel.text = Mathf.Floor(this.TimeLeft).ToString();
	}
}
