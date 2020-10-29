using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAI : MonoBehaviour
{
    public float velocity;
    public float change_direction_time;
    public float t;
    private float timer;
    private float moveAngle;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        moveAngle = Random.Range(0, 360);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > change_direction_time)
        {
            moveAngle = Random.Range(0, 360);
            timer = 0;
        }

        transform.position += (velocity * transform.forward) * Time.deltaTime;
        
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.y = Mathf.LerpAngle(eulerAngles.y, moveAngle, t);
        transform.eulerAngles = eulerAngles;
    }
}
