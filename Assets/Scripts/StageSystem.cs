using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour {
	[SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject StarPrefab;

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
        MakeStage();
	}

	void MakeStage() {
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				if (stageInfo[y, x] == 1)
					InstantiateParts(tilePrefab, new Vector3(x - (width - 1)/2, 0, y - (height - 1)/2));
			}
		}
	}

	void InstantiateParts(GameObject prefab, Vector3 pos) {
		//Debug.Log("pos:"+pos);
		var obj = Instantiate(prefab, pos, Quaternion.identity);
		obj.transform.SetParent(this.transform);
	}

}
