using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField, Range(3, 5)] int maxStarCount = 3;
    [SerializeField] MainCanvas mainCanvas;
    static int s_maxStarCount = 0;
    public static bool isFinish = false;

	// Use this for initialization
	void Start () {
        s_maxStarCount = maxStarCount;
        isFinish = false;
	}

    public static Collider[] GetPlayers() {
        var layerMask = LayerMask.GetMask("Player");
        return Physics.OverlapBox(StageSystem.center, new Vector3(StageSystem.width/2f, 2, StageSystem.height/2f), Quaternion.identity, layerMask);
    }

    public static void StartGame() {
        var players = GetPlayers();
        for (int n = 0; n < players.Length; n++)
            players[n].GetComponent<Charactor>().BeginOperation();
    }

    public void FinishGame(bool isPlayerWinner) {
        if (isFinish) return;
        isFinish = true;
        var players = GetPlayers();
        for (int n = 0; n < players.Length; n++)
            players[n].GetComponent<Charactor>().EndOperation();

        mainCanvas.ShowResult(isPlayerWinner? "YOU WIN!": "YOU LOSE...");
    }

    public static bool IsWinner(int starCount) {
        return starCount >= s_maxStarCount;
    }
}
