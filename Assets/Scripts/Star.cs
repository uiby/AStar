using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Star : MonoBehaviour {
    Collider collider;
    Renderer renderer;
    Vector3 idealPos;
    void Start() {
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
        transform.position = new Vector3(0, 0.5f, 0);
        idealPos = transform.position;
    }
    void OnTriggerEnter(Collider coll) {
        if (coll.tag != "Charactor") return;

        coll.GetComponent<Charactor>().GetStar();
        StartCoroutine(Arrived());
    }

    IEnumerator Arrived() {
        collider.enabled = false;
        renderer.enabled = false;
        Debug.Log(collider.name);
        yield return null;

        DecideNextPos();
        transform.position = idealPos;

        yield return null;

        Show();
    }

    void DecideNextPos() {
        Vector3[] players = GameManager.GetPlayers().Select(col => col.transform.position).ToArray();
        var width = (float)StageSystem.width;
        var height = (float)StageSystem.height;
        var minDiff = 99999f;
        var maxAve = 0f;
        var bestPos = Vector2.zero;

        for (int n = 0; n < 30; n++) {
            var x = Random.Range(-width, width);
            var y = Random.Range(-height, height);
            var pos = new Vector3(x, 0, y);
            if (!StageSystem.HasTile(pos, Vector3.one * 0.1f)) continue;

            var playerDistance = new float[players.Length];
            //各プレイヤーとの距離の比較
            for (int p = 0; p < players.Length; p++) {
                playerDistance[p] = (new Vector2(pos.x, pos.z) - new Vector2(players[p].x, players[p].z)).magnitude;
            }

            var max = playerDistance.Max();
            var min = playerDistance.Min();
            var diff = max - min;
            var ave = playerDistance.Average();

            if (diff > minDiff) continue;
            if (ave < maxAve) continue;
            bestPos.Set(pos.x, pos.z);
            minDiff = diff;
        }

        idealPos = new Vector3(bestPos.x, 0.5f, bestPos.y);
    }

    void Show() {
        renderer.enabled = true;
        collider.enabled = true;
    }
}
