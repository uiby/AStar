using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
