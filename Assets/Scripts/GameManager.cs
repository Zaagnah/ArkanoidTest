using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject player;
    public GameObject ball;
    public GameObject joystick;
    
    public void WinPanel()
    {
        panel.SetActive(true);
        player.SetActive(false);
        ball.SetActive(false);    
        joystick.SetActive(false);    
    }

    public void Restartlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
