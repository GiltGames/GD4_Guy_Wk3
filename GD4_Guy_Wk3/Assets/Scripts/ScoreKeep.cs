using TMPro;
using UnityEngine;

public class ScoreKeep : MonoBehaviour
{

    public int vScore;
    public TextMeshProUGUI vDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vDisplay.text = "Score: " + vScore;
    }
}
