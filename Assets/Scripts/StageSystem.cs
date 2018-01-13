﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour {
	[SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject starPrefab;

	int[,] stageInfo = new int[,]{{1, 1, 1, 1, 1},
								{1, 0, 1, 0, 1},
								{1, 1, 1, 1, 1},
  								{1, 0, 1, 0, 1},
	  							{1, 1, 1, 1, 1}};
    public static Vector3 center;
    public static int width;
    public static int height;

	void Awake() {
        center = transform.position;
        width = stageInfo.GetLength(1);
        height = stageInfo.GetLength(0);
        GenerateStage();
        GenerateStar();
	}

	void GenerateStage() {
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				if (stageInfo[y, x] == 1)
					InstantiateParts(tilePrefab, new Vector3(x - (width - 1)/2, 0, y - (height - 1)/2));
			}
		}
	}

    void GenerateStar() {
        var count = 0;
        while(count < 30) {
            count++;
            var x = Random.Range(-width, width);
            var y = Random.Range(-height, height);
            var pos = new Vector3(x, 0, y);
            if (HasTile(new Vector3(x, 0, y), Vector3.one * 0.3f)) {
                InstantiateParts(starPrefab, pos + Vector3.up * 0.3f);
                break;
            }
        }
    }

	void InstantiateParts(GameObject prefab, Vector3 pos) {
		//Debug.Log("pos:"+pos);
		var obj = Instantiate(prefab, pos, Quaternion.identity);
		obj.transform.SetParent(this.transform);
	}

    bool HasTile(Vector3 center, Vector3 scale) {
        var layerMask = LayerMask.GetMask("Tile");
        return Physics.CheckBox(center, scale/2f, Quaternion.identity, layerMask);
    }
}
