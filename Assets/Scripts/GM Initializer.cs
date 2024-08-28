using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMInitializer : MonoBehaviour
{
    [SerializeField] private bool randomizesine;
    [SerializeField] private float sinespeed;
    [SerializeField] private float sinerange;
    // Start is called before the first frame update
    void Awake()
    {
        GlobalGM.sinerange = sinerange;
        GlobalGM.sinespeed = sinespeed;
        GlobalGM.randomizesine = randomizesine;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GlobalGM.sinerange = sinerange;
        GlobalGM.sinespeed = sinespeed;
        GlobalGM.randomizesine = randomizesine;
    }
}
