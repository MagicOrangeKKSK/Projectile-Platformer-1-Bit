using Godot;
using System;

public partial class Player : PlatformerCharacter2D
{
    [Export(PropertyHint.Range, "0,100,1,or_greater")] public float moveSpeed = 120f;
    [Export(PropertyHint.Range, "0,100,1,or_greater")] public float jumpForce = 350f;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector2(direction.X * moveSpeed, Velocity.Y);
        ApplyGravity(delta);
        MoveAndSlide();
    }

 

    public bool TryJump()
    {
        var isOnFloor = IsOnFloor();
        if (isOnFloor)
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