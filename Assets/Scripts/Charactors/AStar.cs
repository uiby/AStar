using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour {
  int massCount;
  Mass[,] massArrays;

  public void Initialize(int _massCount) {
    massCount = _massCount;
    massArrays = new Mass[massCount, massCount];
  }

  public void MakeMassArrays(int width, int height) {
    var xRange = (float)width/massCount;
    var yRange = (float)height/massCount;
    var yPos = yRange/2f;
    var xPos = xRange/2f;
    for (int y = 0; y < massCount; y++) {
      xPos = xRange/2f;
      for (int x = 0; x < massCount; x++) {
        var center = new Vector3(xPos - width/2f, 0, yPos - height/2f);
        if (HasTile(center, new Vector3(xRange/2f, 0.5f, yRange/2f))) {
          massArrays[y, x] = new Mass(center);
        } else {
          massArrays[y, x] = new Mass();
        }
        xPos += xRange;
      }
      yPos += yRange;
    }
  }

  bool HasTile(Vector3 center, Vector3 scale) {
    var layerMask = LayerMask.GetMask("Tile");
    return Physics.CheckBox(center, scale/2f, Quaternion.identity, layerMask);
  }
}

public class Mass {
  Vector3 pos;
  MassType massType;
  int costToGoal;
  int costFromStart;
  int totalCost; //= costToGoal + costFromStart
  bool searched; 
  bool isMass = false;

  public Mass(Vector3 _pos) {
    isMass = true;
    pos = _pos;
  }

  public Mass() {
    isMass = false;
  }


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