using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MethodsForUI : MonoBehaviour
{
    public void SwitchToLoosingScene()
    {
        SceneManager.LoadScene(2);
    }
    public void SwitchToWinningScene()
    {
        SceneManager.LoadScene(3);
    }
    public void SwitchToPlayinScene()
    {
        SceneManager.LoadScene(1);
    }
}
