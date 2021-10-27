using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneFunc : MonoBehaviour
{
    
    public void LoadAScene(string n)
    {
        SceneManager.LoadScene(n);
    }
    
}
