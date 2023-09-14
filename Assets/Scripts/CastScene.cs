using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastScene : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(OpenScene), 13);
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(1);
    }
}
