using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaFly : MonoBehaviour
{

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 180 * Time.deltaTime));
    }


}
