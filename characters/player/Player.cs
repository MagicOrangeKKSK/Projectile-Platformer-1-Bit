using Godot;
using System;

public partial class Player : PlatformerCharacter2D
{
    [Export(PropertyHint.Range, "0,100,1,or_greater")] public float moveSpeed = 120f;

    [Export] public bool cangroundJump = false;
    [Export(PropertyHint.Range, "0,100,1,or_greater")] public float jumpForce = 350f;

    public override void _PhysicsProcess(double delta)
    {
        var v = Velocity;
        v.X = direction.X * moveSpeed;
        Velocity = v;

        ApplyGravity(delta);
        MoveAndSlide();
    }

 

    public bool TryJump()
    {
        var isOnFloor = IsOnFloor();
        if (cangroundJump && isOnFloor)
        {
            Jump();
            return true;
        }
        return false;
    }

    public void Jump()
    {
        Velocity  -= new Vector2(0, jumpForce);
    }
}