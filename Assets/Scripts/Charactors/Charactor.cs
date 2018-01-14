using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SimpleAnimation))]
public class Charactor : MonoBehaviour {
  [SerializeField] StarCounter starCounter;
  [SerializeField] float walkSpeed;
  [SerializeField] float runSpeed;
  [SerializeField] float turnSpeed;
  [SerializeField] bool isCom;
  Rigidbody rigidbody;
  SimpleAnimation animation;
  int hasStarCount;
  public bool canControl{get; private set;}

  void Awake() {
    rigidbody = GetComponent<Rigidbody>();
    animation = GetComponent<SimpleAnimation>();
    hasStarCount = 0;
    canControl = false;
  }

  Vector3 prevVelocity = Vector3.zero;
  int animationMode = -1;
  public void Walk(float movementValue) {
    if (animationMode != 1) {
      animationMode = 1;
      animation.CrossFade("Walk", 0.05f);
    }
    Move(transform.forward * movementValue * walkSpeed * Time.deltaTime);
  }
  public void Run(float movementValue) {
    if (animationMode != 2) {
      animationMode = 2;
      animation.CrossFade("Run", 0.05f);
    }
    Move(transform.forward * movementValue * runSpeed * Time.deltaTime);
  }

  public void Stop() {
    if (animationMode != 0) {
      animationMode = 0;
      animation.Play("Default");
    }
  }

  public void Turn (float turnValue) {
    // 入力、スピード、フレーム間の時間に基づいて、回転する度数を決定
    float turn = turnValue * turnSpeed * Time.deltaTime;
    // それを y 軸の回転に設定
    Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
    // この回転をリジッドボディの回転に適用
    rigidbody.MoveRotation (rigidbody.rotation * turnRotation);
  }
  public void Turnaround(float deg) {
    transform.rotation = Quaternion.AngleAxis(deg, Vector3.up);
    //float turn = idealAngle - transform.eulerAngles.y;
    // それを y 軸の回転に設定
    //Quaternion turnRotation = Quaternion.Euler (0f, idealAngle, 0f);
    // この回転をリジッドボディの回転に適用
    //rigidbody.MoveRotation (turnRotation);
  }

  void Move(Vector3 value) {
    rigidbody.MovePosition(rigidbody.position + value);    
  }

  public void GetStar() {
    hasStarCount++;
    starCounter.UpdateText(hasStarCount);
    if (GameManager.IsWinner(hasStarCount)) {
      GameObject.Find("GameManager").GetComponent<GameManager>().FinishGame(!isCom);
    }
  }

  public void BeginOperation() {
    canControl = true;
  }

  public void EndOperation() {
    canControl = false;
  }
}
