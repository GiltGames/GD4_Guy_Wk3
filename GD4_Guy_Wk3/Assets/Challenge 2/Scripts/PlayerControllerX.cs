using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float Delay =2f;
    float Timer;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Timer <= 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            Timer = Delay;

        }

        Timer = Timer - Time.deltaTime;

    }
}
