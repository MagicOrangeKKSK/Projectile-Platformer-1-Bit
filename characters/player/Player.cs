using Godot;

public partial class Player : PlatformerCharacter2D
{
    [Export] public PlayerInputActions actions;
    [Export(PropertyHint.Range, "0,100,1,or_greater")] public float moveSpeed = 50f;

    public override void _PhysicsProcess(double delta)
    {
        direction = Input.GetVector(actions.left, actions.right, actions.up, actions.down);

        Velocity = new Vector2(direction.X * moveSpeed, 0);

        MoveAndSlide();
    }
}