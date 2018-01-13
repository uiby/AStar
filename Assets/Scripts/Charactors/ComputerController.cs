using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Charactor))]
public class ComputerController : MonoBehaviour {
    [SerializeField, Range(5, 50)] int massCount = 5;
    Charactor charactor;

    AStar aStar;

	void Start () {
		charactor = transform.GetComponent<Charactor>();
        aStar = (AStar)gameObject.AddComponent<AStar>();
        aStar.Initialize(massCount);
        aStar.MakeMassArrays(StageSystem.width, StageSystem.height);
        aStar.MakePath();
	}
	void Update () {
	}
}
