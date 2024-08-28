using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinrotation : MonoBehaviour
{
    private Vector3 pos;
    private float sine = 0;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        if (GlobalGM.randomizesine)
            sine = Random.Range(0, Mathf.PI * 2);
    }

    // Update is called once per frame
    void Update()
    {
        // sine variable that goes from 0 to 2PI.
        sine = (sine + Time.fixedDeltaTime * GlobalGM.sinespeed)%(Mathf.PI * 2);
        transform.Rotate(0f, 100f * Time.deltaTime, 0f, Space.Self);
        // Makes the coin move up and down
        // Vector3.up * GlobalGM.sinerange * 1.5f, prevents it from clipping into ground
        //(Mathf.Sin(sine) - 0.5f) goes from [-0.5f, 0.5f]
        transform.position = Vector3.up * (Mathf.Sin(sine) - 0.5f) * GlobalGM.sinerange + pos + Vector3.up * GlobalGM.sinerange * 1.5f;
    }
}
