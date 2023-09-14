using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    [SerializeField] private int _level;
    public void OpenScene()
    {
        SceneManager.LoadScene(_level);
    }
}
