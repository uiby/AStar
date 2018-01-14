using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Charactor))]
public class ComputerController : MonoBehaviour {
    [SerializeField, Range(5, 50)] int massCount = 5;
    Charactor charactor;
    AStar aStar;
    List<Vector2> checkPointList;
    int checkCount = 0;

	void Start () {
		charactor = transform.GetComponent<Charactor>();
        aStar = (AStar)gameObject.AddComponent<AStar>();
        aStar.Initialize(massCount);
        aStar.MakeMassArrays(StageSystem.width, StageSystem.height);
        checkPointList = aStar.MakePath();
	}

    void FixedUpdate() {
        if (!charactor.canControl) return;
        if (checkCount < checkPointList.Count) {
            transform.LookAt(Vector3.up * transform.position.y + new Vector3(checkPointList[checkCount].x, 0, checkPointList[checkCount].y));
            charactor.Run(1);
            ArriveCheckPoint();
        } else if (checkCount == checkPointList.Count) {
            charactor.Stop();
            if (!StageSystem.HasStarInStage()) return;
            MakePath();
        } else {
            charactor.Stop();
        }
    }

    void MakePath() {
        checkPointList = aStar.MakePath();
        checkCount = 0;
    }

    void ArriveCheckPoint() {
        var nowPos = new Vector2(transform.position.x, transform.position.z);
        var checkPos = checkPointList[checkCount];

        if ((checkPos - nowPos).magnitude > 0.2f) return;
        checkCount++;
    }
}
