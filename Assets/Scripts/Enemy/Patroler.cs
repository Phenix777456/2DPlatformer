using UnityEngine;

public class Patroler : MonoBehaviour
{
    private float _rotateY = 90f;
    private float _minDistance = 0.5f;


    public Transform CalculateBasicMovement(Transform firstTargetTransform, Transform secondTargetTransform, Transform finalTarget)
    {
        if (transform.position.IsEnoughClose(firstTargetTransform.position, _minDistance))
        {
            finalTarget = secondTargetTransform;
            TurnAround(finalTarget);
        }

        if (transform.position.IsEnoughClose(secondTargetTransform.position, _minDistance))
        {
            finalTarget = firstTargetTransform;
            TurnAround(finalTarget);
        }

        return finalTarget;
    }

    public void TurnAround(Transform finalTarget)
    {
        transform.LookAt(finalTarget);
        transform.Rotate(0, _rotateY, 0);
    }
}
