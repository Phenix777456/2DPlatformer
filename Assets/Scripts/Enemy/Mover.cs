using UnityEngine;

public class Mover : MonoBehaviour
{
    public void Move(Transform targetTransform, float step)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);
    }
}