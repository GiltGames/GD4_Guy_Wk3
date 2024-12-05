using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform Player1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player1.position);
    }
}
