using System.Collections;
using UnityEngine;

public class BallMove : MonoBehaviour {

    void OnDrag (Vector2 delta) {

        float movex = transform.localPosition.x + (delta.x / 3);
        float movey = transform.localPosition.y + (delta.y / 3);
        //避免越界操作，这里可以进行一些判断
        transform.localPosition = new Vector3 (movex, movey, transform.localPosition.z);
    }

}