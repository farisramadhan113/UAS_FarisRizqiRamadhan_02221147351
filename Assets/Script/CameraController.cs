using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistanceX;
    [SerializeField] private float aheadDistanceY;
    [SerializeField] private float cameraSpeed;

    private void Update()
    {
        // Follow player
        float targetX = player.position.x + (player.localScale.x * aheadDistanceX);
        float targetY = player.position.y + (player.localScale.y * aheadDistanceY);

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetX, targetY, transform.position.z), Time.deltaTime * cameraSpeed);
    }
}
