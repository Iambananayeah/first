using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanceBallManager : MonoBehaviour
{
    public Transform ball;

    public float skewAngle;
    public float dieAngle;
    public float moveAngle;
    public int skewDir = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//1=180 o
    {
        if (ball == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseDownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mouseDownPos);
            Vector2 dir = mouseDownPos - (Vector2)ball.transform.position;
            float preZ = ball.transform.rotation.z;
            if (dir.x > 0)
            {
                ball.transform.Rotate(Vector3.back, moveAngle);
            }
            else
            {
                ball.transform.Rotate(Vector3.back, -moveAngle);
            }
            if (ball.transform.rotation.z * preZ < 0)
            {
                skewDir *= -1;
                //Debug.Log("ChangeDir");
            }
        }

        if (Mathf.Abs(ball.transform.rotation.z) > dieAngle)
        {
            Destroy(ball.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (ball == null) return;

        ball.transform.Rotate(Vector3.back, skewAngle * skewDir);



        //Debug.Log(ball.transform.rotation.z);
    }
}
