using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public Camera cam;
    public float maximumLength;

    private Ray mouseRay;
    private Vector3 pos;
    private Vector3 dir;
    private Quaternion rot;

    void Update()
    {
        if (cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            mouseRay = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast (mouseRay.origin, mouseRay.direction, out hit, maximumLength))
            {
                RotateToMouseDirection(gameObject, hit.point);
            }
            else
            {
                var pos = mouseRay.GetPoint(maximumLength);
                RotateToMouseDirection(gameObject, pos);
            }

        }
        else
        {
            Debug.Log("NoCam");
        }
    }

    void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        dir = destination - obj.transform.position;
        rot = Quaternion.LookRotation(dir);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rot, 1);
    }
}
