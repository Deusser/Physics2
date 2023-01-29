using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinballStarter : MonoBehaviour
{
    float power;
    float minPower = 0f;
    [SerializeField] float MaxPower = 100;
    [SerializeField] float powerStep = 5000;
    [SerializeField] Slider powerSlider;
    private Rigidbody ball = null;
    bool ballReady;
    void Start()
    {
        powerSlider.minValue = minPower;
        powerSlider.maxValue = MaxPower;
    }

    void Update()
    {
        if (ball != null)
        {
            ballReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= MaxPower)
                {
                    power += powerStep * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ball.AddForce(power * Vector3.back);
            }
        }
        else
        {
            ballReady = false;
            power = minPower;
        }
        powerSlider.gameObject.SetActive(ballReady);
        powerSlider.value = power;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ball = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ball = null;
        }
    }
}
