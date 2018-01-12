using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Charactor))]
public class PlayerController : MonoBehaviour {
    Charactor charactor;
	// Use this for initialization
	void Start () {
		charactor = transform.GetComponent<Charactor>();
	}
	
	// Update is called once per frame
	void Update () {
        var velocity = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));
        if (velocity.magnitude > 0.01f) {
            charactor.Walk(velocity);
        }
	}
}
