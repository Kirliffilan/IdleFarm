using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerVisual : MonoBehaviour
{
    private Animator _animator;

    private readonly static int IS_MOVING = Animator.StringToHash("IsMoving");
    private readonly static int X = Animator.StringToHash("X");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimateMovement(float x)
    {
        _animator.SetBool(IS_MOVING, true);
        _animator.SetInteger(X, Mathf.RoundToInt(x));
    }

    public void StopMovement()
    {
        _animator.SetBool(IS_MOVING, false);
        _animator.SetInteger(X, Mathf.RoundToInt(0));
    }
}
