using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveSin : MonoBehaviour
{

    float sinCenterY;
    public float amlitude = 2;
    public float frequency = 2;
    public bool inverted = false;

    // Start is called before the first frame update
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frequency) * amlitude;
        sin *= -1.0f;

        if (inverted)
        {
            sin *= -1.0f;

        }
        pos.y = sinCenterY + sin;
        transform.position = pos;
    }   
}
