//This script persists across all scenes. It controls things like score, scene management, and GUI

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pimpin : MonoBehaviour {
    //the various phases of the game
    public int gamePhase;
    const int TITLE = 0;
    const int PLAY = 1;
    const int WIN = 2;
    const int GAME_SELECT = 3;

    public string PlaySceneName;        //name of game "play" scene

    public Font f;


    //Four player scores
    public int Raft1Score;
	public int Raft2Score;
	public int Raft3Score;
	public int Raft4Score;


    public int ScoresX_offset = 118;    //x offset for the score displays


	void Start () {
        DontDestroyOnLoad(transform.gameObject);        //make this object persist across scenes
        gamePhase = TITLE;
	}
	

    //called when the Game Play scene loads
    void InitializePlay()
    {
        Raft1Score = GameObject.Find("Raft1").GetComponent<row_row_row_ya_boat>().score;
        Raft2Score = GameObject.Find("Raft2").GetComponent<row_row_row_ya_boat>().score;
        Raft3Score = GameObject.Find("Raft3").GetComponent<row_row_row_ya_boat>().score;
        Raft4Score = GameObject.Find("Raft4").GetComponent<row_row_row_ya_boat>().score;
    }

    //Called every frame
    void OnGUI()
    {
        GUI.skin.font = f;
                
        if (gamePhase == TITLE)
        {
            GUI.skin.button.fontSize = 60;
            GUI.contentColor = Color.white;
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 8, 3*Screen.height / 4, Screen.width / 4, Screen.height / 7), "Play"))
            {
                gamePhase = GAME_SELECT;
            }
        }
        else if (gamePhase == GAME_SELECT)
        {
            GUI.skin.label.fontSize = 30;
            GUI.Label(new Rect(Screen.width / 2 - Screen.width / 4, 10, Screen.width, Screen.height), "Choose a Game Mode");

            GUI.skin.button.fontSize = 60;
            GUI.contentColor = Color.white;
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 6), "Capture the Flag"))
            {
                SceneManager.LoadSceneAsync(PlaySceneName);
                gamePhase = PLAY;
                InitializePlay();
            }
        }
        else if (gamePhase == PLAY)
        {
            GUI.skin.label.fontSize = 30;
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(Screen.width / 4 - ScoresX_offset, 10, Screen.width, Screen.height), "P1: " + Raft1Score);
            GUI.contentColor = Color.yellow;
            GUI.Label(new Rect(Screen.width / 2 - ScoresX_offset, 10, Screen.width, Screen.height), "P2: " + Raft2Score);
            GUI.contentColor = Color.green;
            GUI.Label(new Rect(3*Screen.width / 4 - ScoresX_offset, 10, Screen.width, Screen.height), "P3: " + Raft3Score);
            GUI.contentColor = Color.blue;
            GUI.Label(new Rect(Screen.width - ScoresX_offset, 10, Screen.width, Screen.height), "P4: " + Raft4Score);
        }
        
    }
}
