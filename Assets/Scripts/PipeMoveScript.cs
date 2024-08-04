using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = -5;
    public float deadZone = -45;
    public PipeSpawnScript spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("PipeSpawn").GetComponent<PipeSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }

        if (spawn.gameActive == false)
        {
            moveSpeed = 0;
        }
    }
}
