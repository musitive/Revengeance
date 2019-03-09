using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public GameObject dont_destroy;
    public static bool im_the_first = true;
    // Start is called before the first frame update
    void Start()
    {
        if(!im_the_first)
        {
            Destroy(gameObject);
        }
        else
        {
            im_the_first = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool first_scene = false;
    public void change_scenes()
    {
        Debug.Log("help me");
        first_scene = !first_scene;
        Object.DontDestroyOnLoad(dont_destroy);
        if (first_scene)
            SceneManager.LoadScene("SwitchingSceneTest");
        else
            SceneManager.LoadScene("Testing");

        
        
    }
}
