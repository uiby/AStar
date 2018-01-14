using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour {
	[SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject wallPrefab;
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
				if (stageInfo[y, x] == 1) {
					InstantiateParts(tilePrefab, new Vector3(x - (width - 1)/2, 0, y - (height - 1)/2));
                } else if (stageInfo[y, x] == 0) {
                    InstantiateParts(wallPrefab, new Vector3(x - (width - 1)/2, 0, y - (height - 1)/2));
                }
			}
		}
	}

    void GenerateStar() {
        InstantiateParts(starPrefab, Vector3.up * 0.3f);
    }

	void InstantiateParts(GameObject prefab, Vector3 pos) {
		//Debug.Log("pos:"+pos);
		var obj = Instantiate(prefab, pos, Quaternion.identity);
		obj.transform.SetParent(this.transform);
	}

    public static bool HasTile(Vector3 center, Vector3 scale) {
        var layerMask = LayerMask.GetMask("Tile");
        return Physics.CheckBox(center, scale/2f, Quaternion.identity, layerMask);
    }

    public static bool HasStar(Vector3 center, Vector3 scale) {
        var layerMask = LayerMask.GetMask("Star");
        return Physics.CheckBox(center, scale/2f, Quaternion.identity, layerMask);
    }
    public static bool HasStarInStage() {
        var layerMask = LayerMask.GetMask("Star");
        return Physics.CheckBox(center, new Vector3(width/2f, 2, height/2f) , Quaternion.identity, layerMask);
    }

    public static Collider GetStar() {
        var layerMask = LayerMask.GetMask("Star");
        return Physics.OverlapBox(center, new Vector3(width/2f, 2, height/2f), Quaternion.identity, layerMask)[0];
    }

}
