using UnityEngine;

public class MousePosition2D : MonoBehaviour
{
    [SerializeField]private Camera mainCamera;
    public Vector2 MousePosition()
    {
        return (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
