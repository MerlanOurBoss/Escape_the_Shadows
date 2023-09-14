using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource audi;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        audi = GetComponent<AudioSource>();
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "WinScene")
        {
            audi.Stop();
        }
    }
}
