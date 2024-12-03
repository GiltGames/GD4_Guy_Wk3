using Unity.VisualScripting;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float vXboundL = -35;
    public float vYboundL =-1;
    public float vZboundL = -25; 
    public float vXboundU = 35;
    public float vYboundU = 30;
    public float vZboundU = 40;
    public GameObject other;
    Vector3 vTempPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        vTempPos = transform.position;

        if (vTempPos.x < vXboundL || vTempPos.y <vYboundL || vTempPos.z <vZboundL|| vTempPos.x >vXboundU || vTempPos.y > vYboundU || vTempPos.z >vZboundU)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);

        }
    }
}
