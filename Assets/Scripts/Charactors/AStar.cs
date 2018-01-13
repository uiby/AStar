using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Mass {
  Vector3 pos;
  MassType massType;
  int costToGoal;
  int costFromStart;
  int totalCost; //= costToGoal + costFromStart
  bool searched; 


  public void Initialize(int initCostToGoal, MassType _massType) {
    costToGoal = initCostToGoal;
    costFromStart = 0;
    totalCost = 0;
    searched = false;
    massType = _massType;
  }

  public void Search(int _costToFromStart) {
    costFromStart = _costToFromStart;
    totalCost = costToGoal + costFromStart;
    searched = true;
  }

}

public enum MassType {
  START,
  ROAD,
  GOAL,
}