using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float RotationDegree = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 RotationDegrees = RotationDegree * new Vector3(x: Random.Range(-3, 4), y: Random.Range(-3, 4), z: Random.Range(-3, 4));
        transform.Rotate(RotationDegrees);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 RotationDegrees = RotationDegree * new Vector3(x: Random.Range(-5, 7),y:1 , z:1);
        transform.Rotate(RotationDegrees * Time.deltaTime);
       
    }
}
