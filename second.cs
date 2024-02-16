using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class second : MonoBehaviour
{
    /* tracks game status */
    bool gameGoing = false;

    /* canvas variables */
    public Button startButton;
    public TMP_Text timerText;
    public TMP_Text bestText;
    public TMP_Text introText;

    /* timer variables */
    float timeElapsed = 0;
    float minutes = 0;
    float seconds = 0;
    float bestTime = 0;
    float bestMinutes = 0;
    float bestSeconds = 0;
    
    /* control and chase variables */
    public GameObject control;
    public GameObject chase;

    float resetControl;
    float resetChase;

    float controlPos;
    float chasePos;

    /* control variables */
    public float speed = 2f;
    float horizontalInput;

    /* chase lerp variables */
    public float transitionTime = 5;
    Vector3 startChase;
    Vector3 endChase;
    bool hasReached = false;
    float lerpValue = 0;
    int endX;
    int min = -10; // line left x
    int max = 10; // line right x

    // Start is called before the first frame update
    void Start()
    {
        /* sets reset variables to initial GO positions */
        resetControl = control.gameObject.transform.position.x;
        resetChase = chase.gameObject.transform.position.x;

        startButton.onClick.AddListener(()=> {
            introText.gameObject.SetActive(false);
            timeElapsed = 0;
            lerpValue = 0;
            hasReached = false;
            gameGoing = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (gameGoing == true) {
            /* updates timer variable */
            timeElapsed += Time.deltaTime;
            minutes = Mathf.FloorToInt(timeElapsed/60);
            seconds = Mathf.FloorToInt(timeElapsed%60);
            timerText.text = (minutes.ToString()+":"+seconds.ToString());

            /* gets and sets horizontal input */
            horizontalInput = Input.GetAxis("Horizontal"); 
            controlPos = control.gameObject.transform.position.x + speed * horizontalInput;

            /* control jumps from each end of line */
            if (controlPos > 10f) {
                controlPos = -10f;
            }
            if (controlPos < -10f) {
                controlPos = 10f;
            }

            /* updates control pos */
            control.gameObject.transform.position = new Vector3(controlPos, control.gameObject.transform.position.y, control.gameObject.transform.position.z);

            /* end of lerp: sets up next chase lerp variables */
            if (hasReached == false) {
                startChase = chase.gameObject.transform.position;
                endX = UnityEngine.Random.Range(min,max+1);
                Debug.Log(endX);
                endChase = new Vector3(endX, chase.gameObject.transform.position.y, chase.gameObject.transform.position.z);
                hasReached = true;
            }

            /* once setup is done, perform lerp */
            if (hasReached == true) {
                if (lerpValue < 1) {
                    lerpValue += Time.deltaTime / transitionTime;
                    chase.gameObject.transform.position = Vector3.Lerp(startChase, endChase, lerpValue);
                }
                else {
                    lerpValue = 0;
                    hasReached = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider col){
        Debug.Log("Collision: " + col.gameObject.name);

        if(col.gameObject.name == "chase"){
            gameGoing = false;
            control.gameObject.transform.position = new Vector3(resetControl, control.gameObject.transform.position.y, control.gameObject.transform.position.z);
            chase.gameObject.transform.position = new Vector3(resetChase, chase.gameObject.transform.position.y, chase.gameObject.transform.position.z);
            if (timeElapsed > bestTime) {
                bestTime = timeElapsed;
                bestMinutes = Mathf.FloorToInt(bestTime/60);
                bestSeconds = Mathf.FloorToInt(bestTime%60);
                bestText.text = ("Best: " + minutes.ToString()+":"+seconds.ToString());
            }
            timerText.text = ("0:00");
        }
    }
}