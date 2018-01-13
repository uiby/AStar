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
    if (movement > 0f) {
      charactor.Run(movement);
    } else if (movement < 0f) {
      charactor.Walk(movement);
    } else {
      charactor.Stop();
    }
    charactor.Turn(turn);
  }
}
