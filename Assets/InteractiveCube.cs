using UnityEngine;

public class InteractiveCube : MonoBehaviour
{
    public enum CubeType
    {
        BlueGrow,
        RedShrink,
        GreenJump,
        PurpleSpeed,
        OrangeRotate,
        BlackReset
    }

    public CubeType cubeType;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerController player = other.GetComponent<PlayerController>();
        if (player == null)
            return;

        switch (cubeType)
        {
            case CubeType.BlueGrow:
                player.Grow(0.2f);
                break;

            case CubeType.RedShrink:
                player.Shrink(0.2f);
                break;

            case CubeType.GreenJump:
                player.JumpUp();
                break;

            case CubeType.PurpleSpeed:
                player.ChangeSpeed(2f);
                break;

            case CubeType.OrangeRotate:
                player.Spin();
                break;

            case CubeType.BlackReset:
                player.ResetPlayer();
                break;
        }

        Destroy(gameObject);
    }
}
