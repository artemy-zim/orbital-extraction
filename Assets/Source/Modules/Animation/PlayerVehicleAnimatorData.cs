using UnityEngine;

public static class PlayerVehicleAnimatorData
{
    public static class Params
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        public static readonly int Angle = Animator.StringToHash(nameof(Angle));
    }
}
