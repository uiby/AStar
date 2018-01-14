using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Charactor))]
public class PlayerController : MonoBehaviour {
    Charactor charactor;
    float vertical = 0;
    float horizontal = 0;

    float preDeg = 0f;
    float deg = 0f;
    void Start () {
        charactor = transform.GetComponent<Charactor>();
    }

    void Update () {
        if (!charactor.canControl) return;
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        preDeg = deg;
        deg = Mathf.Atan2(vertical, -horizontal) * Mathf.Rad2Deg - 90;
    }

    void FixedUpdate() {
        if (!charactor.canControl) return;

        if (preDeg != deg)
            charactor.Turnaround(deg);
        if (canRun()) {
            if (horizontal != 0 && vertical != 0)
                charactor.Run(1);
            else if (horizontal != 0)
                charactor.Run(Mathf.Abs(horizontal));
            else if (vertical != 0)
                charactor.Run(Mathf.Abs(vertical));
        }
        else
            charactor.Stop();
    }

    bool canRun() {
        return vertical != 0f || horizontal != 0;
    }
}
