using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class Rooting : MonoBehaviour
{

    public GameObject arrowHead;
    public GameObject risingText;
    public GameObject bow;
    private float posX;
    private float posY;
    float length;
    private Ray mouseRay1;
    private RaycastHit rayHit;
    GameObject arrow;
    float arrowStartX;
    Vector3 stringPullout;

    void Start()
    {


    }
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    void Update()
    {
    }
    public void prepareArrow()
    {
        // get the touch point on the screen
        mouseRay1 = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay1, out rayHit, 1000f))
        {
            posX = this.rayHit.point.x;
            posY = this.rayHit.point.y;
            // ustawienie nachylenia kąta strzału
            Vector2 mousePos = new Vector2(transform.position.x - posX, transform.position.y - posY);
            float angleZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angleZ);
            // wystrzal
            length = mousePos.magnitude / 3f;
            length = Mathf.Clamp(length, 0, 1);
            // renderek
            stringPullout = new Vector3(-(0.44f + length), -0.06f, 2f);
            // Ustawienie pozycji strzały
            Vector3 arrowPosition = arrow.transform.localPosition;
            arrowPosition.x = (arrowStartX - length);
            arrow.transform.localPosition = arrowPosition;
        }
    }
}
