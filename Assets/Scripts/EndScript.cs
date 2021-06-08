using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}

