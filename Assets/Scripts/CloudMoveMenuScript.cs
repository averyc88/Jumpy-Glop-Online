using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoveMenuScript : MonoBehaviour
{
    public float moveSpeed = -8;
    public float deadZone = -15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}