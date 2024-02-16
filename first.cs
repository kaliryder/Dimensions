using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class first : MonoBehaviour
{
    public GameObject sphere;

    MeshRenderer meshRend;

    public bool isScaleGoing = false;
    public bool isBig = false;

    public float scaleTransitionSpeed = 2;
    float scaleLerpValue = 0;

    public float colorTransitionSpeed = 2;
    float colorTimer = 0;

    public Color initialColor;
    public Color fadeColor1;
    public Color fadeColor2;

    Vector3 initialSphereScale = new Vector3(1f,1f,1f);
    Vector3 endSphereScale = new Vector3(2.5f,2.5f,2.5f);

    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
        //sets up MeshRenderer

        initialColor = meshRend.material.color;
        //sets initialColor to sphere color
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver() { 
        meshRend.material.color = Color.Lerp(initialColor, fadeColor1, colorTimer / colorTransitionSpeed);
        colorTimer += Time.deltaTime;
        meshRend.material.color = Color.Lerp(fadeColor1, fadeColor2, colorTimer / colorTransitionSpeed);
        colorTimer += Time.deltaTime;
        isScaleGoing = true;
        if (isScaleGoing == true) {
            if (scaleLerpValue < 1) {
                scaleLerpValue += Time.deltaTime / scaleTransitionSpeed;
                sphere.transform.localScale = Vector3.Lerp(initialSphereScale, endSphereScale, scaleLerpValue);                        
                isBig = true;
            }
            else {
                scaleLerpValue = 0;
                isScaleGoing = false;
            }
        }
    }

    void OnMouseExit() {
        transform.localScale = initialSphereScale;
        isScaleGoing = false;
    }
}
