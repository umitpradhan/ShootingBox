using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    private float _canonSpeed = 20.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * _canonSpeed * Time.deltaTime);

        if (transform.position.z >= 6.0f)
        {
            Debug.Log(transform.position);
            Destroy(this.gameObject);
        }
        else
            Debug.Log(transform.position);
    }
}
