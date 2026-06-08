using Godot;

public partial class PlayerInput : Node
{
    [Export] public Player character;
    [Export] public Shooter shooter;
    [Export] public PlayerInputActions actions;

    public override void _PhysicsProcess(double delta)
    {
        character.direction = Input.GetVector(actions.left, actions.right, actions.up, actions.down);


    }


    public override void _UnhandledInput(InputEvent e)
    {
        if (e.IsActionPressed(actions.jump))
        {
            character.TryJump();
        }
    
        if (e.IsActionPressed(actions.shoot))
        {
            shooter.TryShoot();
        }
    }

}
