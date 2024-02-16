using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchscene : MonoBehaviour
{
    bool fromFirst = false;
    bool fromSecond = false;
    bool fromThird = false;

    int first = 7;
    int second = 13;
    int third = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Loads main
    public void loadMain() {
        SceneManager.LoadScene("Forest");
        if (fromFirst == true) {
            screencount.count = first;
        }
        if (fromSecond == true) {
            screencount.count = second;
        }
        if (fromThird == true) {
            screencount.count = third;
        }
        fromFirst = false;
        fromSecond = false;
        fromThird = false;
    }

    // Loads 1D game
    public void loadFirst() {
        SceneManager.LoadScene("First");
        fromFirst = true;
    }

    // Loads 2D game
    public void loadSecond() {
        SceneManager.LoadScene("Second");
        fromSecond = true;
    }

    // Loads 3D game
    public void loadThird() {
        SceneManager.LoadScene("BallDrop");
        fromThird = true;
    }
}
