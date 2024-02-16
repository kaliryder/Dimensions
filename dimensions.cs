using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dimensions : MonoBehaviour
{
    /* Canvas */
    public Button leftButton;
    public Button rightButton;
    public TMP_Text topText;
    public TMP_Text coordsText;
    public Button firstButton;
    public Button secondButton;
    public Button thirdButton;

    /* First Dimension Variables */
    public GameObject point1;
    public GameObject point2;
    public GameObject line;
    Vector3 startPoint1pos = new Vector3(-18,3,100);
    Vector3 midPoint1pos = new Vector3(-18,3,95);
    Vector3 endPoint1pos = new Vector3(-18,3,105);
    Vector3 startPoint2pos = new Vector3(-26,3,105);
    Vector3 midPoint2pos = new Vector3(-18,3,105);
    Vector3 endPoint2pos = new Vector3(-18,3,95);
    Vector3 startLinePos = new Vector3(-26,3,100);
    Vector3 endLinePos = new Vector3(-18,3,100);

    /* Second Dimension Variables */
    public GameObject point3;
    public GameObject line1;
    public GameObject line2;
    Vector3 startLine2pos = new Vector3(-26,5.5f,200);
    Vector3 endLine2pos = new Vector3(-18,5.5f,200);
    Vector3 startPoint3pos = new Vector3(-18,3,205);
    Vector3 mid1Point3pos = new Vector3(-18,3,195);
    Vector3 mid2Point3pos = new Vector3(-18,3,200);
    Vector3 mid3Point3pos = new Vector3(-18,8,200);
    Vector3 endPoint3pos = new Vector3(-18,3,200);

    /* Third Dimension Variables */
    public GameObject point4;
    public GameObject line3;
    public GameObject line4;
    Vector3 startLine3pos = new Vector3(-18,3,300);
    Vector3 endLine3pos = new Vector3(-18,3,304);
    Vector3 startLine4pos = new Vector3(-30,3,300);
    Vector3 endLine4pos = new Vector3(-14,3,300);
    Vector3 startPoint4pos = new Vector3(-18,3,300);
    Vector3 mid1Point4pos = new Vector3(-10,10,300);
    Vector3 mid2Point4pos = new Vector3(-18,10,308);
    Vector3 mid3Point4pos = new Vector3(-11,3,307);
    Vector3 endPoint4pos = new Vector3(-18,3,300);

    /* Camera */
    Camera mainCam;
    Vector3 startPosition;
    Vector3 endPosition;

    /* Lerp Variables */
    public float transitionTime = 10;
    float lerpValue = 0;
    bool isGoing = false;
    bool isGoingLeft = false;
    bool isGoingRight = false;

    /* Screens */
    int numScreens = 21;
    int screenCounter = 0;
    Screen[] screenArray;

    /* Dimension Start Index */
    int zeroStart = 0;
    int firstStart = 3;
    int secondStart = 8;
    int thirdStart = 14;
    int fourthStart = 21;

    /* Zeroeth Dimension Screens */
    Screen screen0 = new Screen("We start with a point.", "", new Vector3(-10,3,0));
    Screen screen1 = new Screen("This point has no size. It is simply an imagined position in space.", "", new Vector3(-8,3,0));
    Screen screen2 = new Screen("We will use this point to travel through dimensions.", "", new Vector3(-6,3,0));

    /* First Dimension Screens */
    Screen screen3 = new Screen("Let's travel to the first dimension.", "", new Vector3(-6,3,100));
    Screen screen4 = new Screen("We can begin by adding a second point.", "", new Vector3(-6,3,100));
    Screen screen5 = new Screen("Now, we can connect these points to create an axis.", "", new Vector3(-6,3,100));
    Screen screen6 = new Screen("We can assign our points a single unit of measurement along this axis.", "", new Vector3(-6,3,100));
    Screen screen7 = new Screen("We will bring this axal movement with us to the next dimension.", "(0)", new Vector3(-8,3,100));

    /* Second Dimension Screens */
    Screen screen8 = new Screen("We will now travel into the second dimension.", "", new Vector3(-5,6,200));
    Screen screen9 = new Screen("In order to do this, we need to add a second axis.", "", new Vector3(-5,6,200));
    Screen screen10 = new Screen("Now, our point can move freely in the second dimension.", "", new Vector3(-5,6,200));
    Screen screen11 = new Screen("We can assign this point a pair of coordinates to identify its location.", "(0,0)", new Vector3(-5,6,200));
    Screen screen12 = new Screen("You may be familiar with the second dimension grid from basic math.", "(0,1)", new Vector3(-5,6,200));
    Screen screen13 = new Screen("We will take these axes with us to the third dimension.", "", new Vector3(-5,6,200));

    /* Third Dimension Screens */
    Screen screen14 = new Screen("It's time to explore the third dimension.", "", new Vector3(-3,6,300));
    Screen screen15 = new Screen("First, we will add a third axis.", "", new Vector3(0,6,303));
    Screen screen16 = new Screen("We can locate our point with the xyz coordinate system.", "(0,1,1)", new Vector3(0,6,303));
    Screen screen17 = new Screen("This is the dimension we are most familiar with, as we are three-dimensional beings.", "(1,1,0)", new Vector3(0,6,303));
    Screen screen18 = new Screen("Objects in this dimension have depth, length, and width.", "(1,1,1)", new Vector3(0,6,303));
    Screen screen19 = new Screen("All of your experiences have been in the third dimension.", "(0,0,0)", new Vector3(0,6,303));
    Screen screen20 = new Screen("This is the only dimension we may ever see.", "", new Vector3(0,6,303));

    // Start is called before the first frame update
    void Start()
    {
        /* Set Up Camera */
        mainCam = Camera.main;
        mainCam.enabled = true;

        /* Set Up Buttons */
        leftButton.onClick.AddListener(leftPressed);
        rightButton.onClick.AddListener(rightPressed);

        /* Set Up Screen Array */
        screenArray = new Screen[numScreens];

        /* Zeroeth Dimension */
        screenArray[0] = screen0;
        screenArray[1] = screen1;
        screenArray[2] = screen2;
        screenArray[2].setPointPos(startPoint1pos, startPoint2pos);
        screenArray[2].setLinePos(startLinePos);

        /* First Dimension */
        screenArray[3] = screen3;
        screenArray[3].setPointPos(startPoint1pos, startPoint2pos);
        screenArray[3].setLinePos(startLinePos);
        screenArray[4] = screen4;
        screenArray[4].setPointPos(midPoint1pos, midPoint2pos);
        screenArray[4].setLinePos(startLinePos);
        screenArray[5] = screen5;
        screenArray[5].setPointPos(midPoint1pos, midPoint2pos);
        screenArray[5].setLinePos(endLinePos);
        screenArray[6] = screen6;
        screenArray[6].setPointPos(endPoint1pos, endPoint2pos);
        screenArray[6].setLinePos(endLinePos);
        screenArray[7] = screen7;
        screenArray[7].setPointPos(endPoint1pos, endPoint2pos);
        screenArray[7].setLinePos(endLinePos);
        screenArray[7].setPoint3Pos(startPoint3pos);
        screenArray[7].setLine2Pos(startLine2pos);

        /* Second Dimension */
        screenArray[8] = screen8;
        screenArray[8].setPoint3Pos(startPoint3pos);
        screenArray[8].setLine2Pos(startLine2pos);
        screenArray[9] = screen9;
        screenArray[9].setPoint3Pos(startPoint3pos);
        screenArray[9].setLine2Pos(endLine2pos);
        screenArray[10] = screen10;
        screenArray[10].setPoint3Pos(mid1Point3pos);
        screenArray[10].setLine2Pos(endLine2pos);
        screenArray[11] = screen11;
        screenArray[11].setPoint3Pos(mid2Point3pos);
        screenArray[11].setLine2Pos(endLine2pos);
        screenArray[12] = screen12;
        screenArray[12].setPoint3Pos(mid3Point3pos);
        screenArray[12].setLine2Pos(endLine2pos);
        screenArray[13] = screen13;
        screenArray[13].setPoint3Pos(endPoint3pos);
        screenArray[13].setLine2Pos(endLine2pos);

        /* Third Dimension */
        screenArray[14] = screen14;
        screenArray[14].setPoint4Pos(startPoint4pos);
        screenArray[14].setLine3Pos(startLine3pos);
        screenArray[14].setLine4Pos(startLine4pos);
        screenArray[14].setPoint3Pos(endPoint3pos);
        screenArray[14].setLine2Pos(endLine2pos);
        screenArray[15] = screen15;
        screenArray[15].setPoint4Pos(startPoint4pos);
        screenArray[15].setLine3Pos(endLine3pos);
        screenArray[15].setLine4Pos(endLine4pos);
        screenArray[16] = screen16;
        screenArray[16].setPoint4Pos(mid1Point4pos);
        screenArray[16].setLine3Pos(endLine3pos);
        screenArray[16].setLine4Pos(endLine4pos);
        screenArray[17] = screen17;
        screenArray[17].setPoint4Pos(mid2Point4pos);
        screenArray[17].setLine3Pos(endLine3pos);
        screenArray[17].setLine4Pos(endLine4pos);
        screenArray[18] = screen18;
        screenArray[18].setPoint4Pos(mid3Point4pos);
        screenArray[18].setLine3Pos(endLine3pos);
        screenArray[18].setLine4Pos(endLine4pos);
        screenArray[19] = screen19;
        screenArray[19].setPoint4Pos(endPoint4pos);
        screenArray[19].setLine3Pos(endLine3pos);
        screenArray[19].setLine4Pos(endLine4pos);
        screenArray[20] = screen20;
        screenArray[20].setPoint4Pos(endPoint4pos);
        screenArray[20].setLine3Pos(endLine3pos);
        screenArray[20].setLine4Pos(endLine4pos);
    }

    // Update is called once per frame
    void Update()
    {
        screenCounter = screencount.count;
        Debug.Log(screenCounter);
        
        /* Update Canvas Screen */
        topText.text = screenArray[screenCounter].getText();
        coordsText.text = screenArray[screenCounter].getCoords();
        firstButton.gameObject.SetActive(false);
        secondButton.gameObject.SetActive(false);
        thirdButton.gameObject.SetActive(false);

        if (screenCounter == 7) {
            firstButton.gameObject.SetActive(true);
        }
        if (screenCounter == 13) {
            secondButton.gameObject.SetActive(true);
        }
        if (screenCounter == 20) {
            thirdButton.gameObject.SetActive(true);
        }
  
        /* Lerp */
        if (isGoing == true) {
            /* Left Setup */
            if (isGoingLeft == true) {
                if (screenCounter+1 <= numScreens) {
                    /* Camera Lerp Setup */
                    startPosition = screenArray[screenCounter+1].getCamCoords();
                    endPosition = screenArray[screenCounter].getCamCoords();
                    /* First Dimension Lerp Setup */
                    if (screenCounter >= firstStart && screenCounter < secondStart) {
                        startPoint1pos = screenArray[screenCounter+1].getPoint1Pos();
                        endPoint1pos = screenArray[screenCounter].getPoint1Pos();
                        startPoint2pos = screenArray[screenCounter+1].getPoint2Pos();
                        endPoint2pos = screenArray[screenCounter].getPoint2Pos();
                        startLinePos = screenArray[screenCounter+1].getLinePos();
                        endLinePos = screenArray[screenCounter].getLinePos();
                    }
                    /* Second Dimension Lerp Setup */
                    if (screenCounter >= secondStart && screenCounter <= thirdStart) {
                        startPoint3pos = screenArray[screenCounter+1].getPoint3Pos();
                        endPoint3pos = screenArray[screenCounter].getPoint3Pos();
                        startLine2pos = screenArray[screenCounter+1].getLine2Pos();
                        endLine2pos = screenArray[screenCounter].getLine2Pos();
                    }
                    /* Third Dimension Lerp Setup */
                    if (screenCounter >= thirdStart && screenCounter < fourthStart) {
                        startPoint4pos = screenArray[screenCounter+1].getPoint4Pos();
                        endPoint4pos = screenArray[screenCounter].getPoint4Pos();
                        startLine3pos = screenArray[screenCounter+1].getLine3Pos();
                        endLine3pos = screenArray[screenCounter].getLine3Pos();
                        startLine4pos = screenArray[screenCounter+1].getLine4Pos();
                        endLine4pos = screenArray[screenCounter].getLine4Pos();
                    }
                }
            }
            /* Right Setup */
            else if (isGoingRight == true) {
                if (screenCounter-1 >= 0) {
                    /* Camera Lerp Setup */
                    startPosition = screenArray[screenCounter-1].getCamCoords();
                    endPosition = screenArray[screenCounter].getCamCoords();
                    /* First Dimension Lerp Setup */
                    if (screenCounter >= firstStart && screenCounter < secondStart) {
                        startPoint1pos = screenArray[screenCounter-1].getPoint1Pos();
                        endPoint1pos = screenArray[screenCounter].getPoint1Pos();
                        startPoint2pos = screenArray[screenCounter-1].getPoint2Pos();
                        endPoint2pos = screenArray[screenCounter].getPoint2Pos();
                        startLinePos = screenArray[screenCounter-1].getLinePos();
                        endLinePos = screenArray[screenCounter].getLinePos();
                    }
                    /* Second Dimension Lerp Setup */
                    if (screenCounter >= secondStart && screenCounter <= thirdStart) {
                        startPoint3pos = screenArray[screenCounter-1].getPoint3Pos();
                        endPoint3pos = screenArray[screenCounter].getPoint3Pos();
                        startLine2pos = screenArray[screenCounter-1].getLine2Pos();
                        endLine2pos = screenArray[screenCounter].getLine2Pos();
                    }
                    /* Third Dimension Lerp Setup */
                    if (screenCounter >= thirdStart && screenCounter < fourthStart) {
                        startPoint4pos = screenArray[screenCounter-1].getPoint4Pos();
                        endPoint4pos = screenArray[screenCounter].getPoint4Pos();
                        startLine3pos = screenArray[screenCounter-1].getLine3Pos();
                        endLine3pos = screenArray[screenCounter].getLine3Pos();
                        startLine4pos = screenArray[screenCounter-1].getLine4Pos();
                        endLine4pos = screenArray[screenCounter].getLine4Pos();
                    }
                }
            }
            /* Lerp */
            if (screenCounter-1 >= 0 && screenCounter+1 <= numScreens) {
                if (lerpValue < 1) {
                    lerpValue += Time.deltaTime / transitionTime;
                    /* Camera Lerp */
                    mainCam.gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, lerpValue);
                    /* First Dimension Lerp */
                    point1.gameObject.transform.position = Vector3.Lerp(startPoint1pos, endPoint1pos, lerpValue);
                    point2.gameObject.transform.position = Vector3.Lerp(startPoint2pos, endPoint2pos, lerpValue);
                    if (screenCounter >= firstStart-1 && screenCounter < secondStart) {
                        line.gameObject.transform.position = Vector3.Lerp(startLinePos, endLinePos, lerpValue);
                    }
                    /* Second Dimension Lerp */
                    point3.gameObject.transform.position = Vector3.Lerp(startPoint3pos, endPoint3pos, lerpValue);
                    line2.gameObject.transform.position = Vector3.Lerp(startLine2pos, endLine2pos, lerpValue);
                    /* Third Dimension Lerp */
                    point4.gameObject.transform.position = Vector3.Lerp(startPoint4pos, endPoint4pos, lerpValue);
                    line3.gameObject.transform.position = Vector3.Lerp(startLine3pos, endLine3pos, lerpValue);
                    line4.gameObject.transform.position = Vector3.Lerp(startLine4pos, endLine4pos, lerpValue);
                }
                else {
                    lerpValue = 0;
                    isGoing = false;
                    isGoingLeft = false;
                    isGoingRight = false;
                }
            }
        }
    }

    void leftPressed() {
        if (screenCounter == 0) {
            // do nothing
        }
        else {
            screenCounter--;
            isGoing = true;
            isGoingLeft = true;
        }
    }

    void rightPressed() {
        if (screenCounter == numScreens-1) {
            // do nothing
        }
        else {
            screenCounter++;
            isGoing = true;
            isGoingRight = true;
        }
    }
}
