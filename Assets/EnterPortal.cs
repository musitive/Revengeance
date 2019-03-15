using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPortal : MonoBehaviour
{
    public string next_scene;
    private GameObject dont_destroy;
    // Start is called before the first frame update
    void Start()
    {
        dont_destroy = GameObject.Find("GameManager");
    }

    //loads the next scene
    //asks SceneManager to do the OnScreenLoaded once it finishes loading
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Object.DontDestroyOnLoad(dont_destroy);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(next_scene);

 

    }

    //Finds spawn points and player
    //sets players new position to spawn point
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject new_location_object = GameObject.Find("SpawnPoint");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new_location_object.transform.position;
    }



}
