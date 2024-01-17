using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position; //posicion inicial
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){return;}
        float cycles = Time.time/period; 

        const float tau = Mathf.PI*2; //constante con valor de 6,283
        float rawSinWavw = Mathf.Sin(cycles*tau); //rango de -1 a 1

        movementFactor = (rawSinWavw + 1f)/2f; //recalcular para ir de 0 a 1

        Vector3 offset = movementVector*movementFactor;
        transform.position = startingPosition + offset;
    }
}
