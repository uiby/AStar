﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour {
	[SerializeField]
	GameObject tilePrefab;

	int[,] stageInfo = new int[,]{{1, 1, 1, 1, 1},
																{1, 0, 1, 0, 1},
																{1, 1, 1, 1, 1},
  															{1, 0, 1, 0, 1},
	  														{1, 1, 1, 1, 1}};

  Vector3 center;

	void Start() {
    center = transform.position;
		MakeStage();
	}


	void MakeStage() {
		var yLength = stageInfo.GetLength(0);
		var xLength = stageInfo.GetLength(1);

		for (int y = 0; y < yLength; y++) {
			for (int x = 0; x < xLength; x++) {
				if (stageInfo[y, x] == 1)
					InstantiateParts(tilePrefab, new Vector3(x - (xLength - 1)/2, 0, y - (yLength - 1)/2));
			}
		}
	}

	void InstantiateParts(GameObject prefab, Vector3 pos) {
		//Debug.Log("pos:"+pos);
		var obj = Instantiate(prefab, pos, Quaternion.identity);
		obj.transform.SetParent(this.transform);
	}

}
