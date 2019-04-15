using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingStart : MonoBehaviour
{

    public Image image;
    private int COUNT_MAX = 60;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = COUNT_MAX;
    }

    // Update is called once per frame
    void Update()
    {
        count--;
        if(count < 0) {
            image.enabled = false;
        }
        else {
            image.enabled = true;
        }
        if(count == -COUNT_MAX) {
            count = COUNT_MAX;
        }
    }
}
