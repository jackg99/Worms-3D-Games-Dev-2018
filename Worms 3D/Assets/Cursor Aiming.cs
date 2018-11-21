using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAiming : MonoBehaviour {
    public float speed = 10;
	
	void FixedUpdate () {
        Plane player = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdistance = 0.0f;
        if(player.Raycast(ray,out hitdistance))
        {
            Vector3 target = ray.GetPoint(hitdistance);

            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
	}
}
