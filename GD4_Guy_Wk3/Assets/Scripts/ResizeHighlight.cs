using UnityEngine;

public class ResizeHighlight : MonoBehaviour
{
    public float vThrowForce;
    public float vThrowForceInc;
    public float vThrowForceLim;
    public float vThrowSizSca;
    public Vector3 vScaleStart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vScaleStart = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
        {

            vThrowForce += vThrowForceInc *Time.deltaTime;

            if (vThrowForce > vThrowForceLim)
            {
                vThrowForce = vThrowForceLim;
            }

            transform.localScale = vScaleStart  * (1 +(vThrowSizSca * (vThrowForce/vThrowForceLim)));

            Debug.Log("sacel   "+ transform.localScale);


        }




       

            if (Input.GetButtonUp("Fire1"))
            {
            
            Destroy(gameObject);


            }


        }
}
