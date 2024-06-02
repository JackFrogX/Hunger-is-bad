using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private MousePosition2D mousePosition2D;
    [SerializeField] private Player player;
    
    private void Update() {
        Vector3 target = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
        Vector3 newPos = Vector3.Lerp(transform.position, target, speed);
        transform.position = newPos;
    }
}
