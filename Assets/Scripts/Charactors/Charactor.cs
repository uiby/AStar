using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
public class Charactor : MonoBehaviour {
    [SerializeField]
    float walkSpeed;
    Rigidbody rigidbody;
    CharacterController charaController;
    void Awake() {
        rigidbody = transform.GetComponent<Rigidbody>();
        charaController = transform.GetComponent<CharacterController>();
    }

    Vector3 prevVelocity = Vector3.zero;
    public void Walk(Vector3 velocity) {
        var movement =  Vector3.MoveTowards(prevVelocity, velocity, Time.deltaTime) * walkSpeed * Time.deltaTime;
        prevVelocity = movement;
        transform.LookAt(transform.position + movement);
        charaController.Move(movement);
    }
}
