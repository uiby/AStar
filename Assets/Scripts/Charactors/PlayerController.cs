using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Charactor))]
public class PlayerController : MonoBehaviour {
  Charactor charactor;
  float movement = 0;
  float turn = 0;
  void Start () {
    charactor = transform.GetComponent<Charactor>();
  }

  void Update () {
    movement = Input.GetAxis("Vertical");
    turn = Input.GetAxis("Horizontal");
  }

  void FixedUpdate() {
    if (movement > 0)
        charactor.Run(movement);
    else charactor.Walk(movement);
    charactor.Turn(turn);
  }
}
