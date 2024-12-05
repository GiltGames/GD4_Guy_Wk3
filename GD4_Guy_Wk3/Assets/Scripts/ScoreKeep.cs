using TMPro;
using UnityEngine;

public class ScoreKeep : MonoBehaviour
{

    public int vScore;
    public int vLives=3;
    public bool vGameOver = false;
    public TextMeshProUGUI vDisplay;
    public TextMeshProUGUI vLiveDisplay;
    public TextMeshProUGUI vGameOverDisp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vGameOverDisp.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        vDisplay.text = "Score: " + vScore;
        vLiveDisplay.text = "Lives: " + vLives;

        if (vGameOver)

        { vGameOverDisp.text = "Game Over"; }

       

    }
}
