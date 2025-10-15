using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BoundsCheck : MonoBehaviour
{
    /// <summary>
    /// Keeps a GameObject on the screen.
    /// Note that this ONLY works for an orthographic Main Camera.
    /// </summary>

    public enum eType { center, inset, outset };

    [Header("Inscribed")]
    public eType boundsType = eType.center;
    public float radius = 1f;

    [Header("Dynamic")]
    public float camWidth;
    public float camHeight;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        // Find the checkRadius that will enable center, inset, or outset     // b
        float checkRadius = 0;
        if (boundsType == eType.inset) checkRadius = -radius;
        if (boundsType == eType.outset) checkRadius = radius;


        Vector3 pos = transform.position;

        // Restrict the X position to camWidth
        if (pos.x > camWidth)
        {                                             
            pos.x = camWidth;                                      
        }
        if (pos.x < -camWidth)
        {
            pos.x = -camWidth;                                              
        }

        // Restrict the Y position to camHeight
        if (pos.y > camHeight)
        {                                          
            pos.y = camHeight;                                          
        }
        if (pos.y < -camHeight)
        {                                       
            pos.y = -camHeight;                                  
        }

        transform.position = pos;
    }


}
