using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    private float twist;

    // Update is called once per frame
    void Update()
    {
        twist += 3;
        this.transform.eulerAngles = new Vector3(0f, twist, 0f);
    }
}
