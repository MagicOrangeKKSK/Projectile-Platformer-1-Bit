using Godot;
using System;

public partial class Facing : Node2D
{
    private PlatformerCharacter2D _character;

    [Export] public PlatformerCharacter2D Character
    {
        set
        {
            if(IsInstanceValid(_character))
            {
                _character.DirectionChanged -= OnDirectionChanged;
            }
            
            _character = value;

            if(IsInstanceValid(_character))
            {       
                _character.DirectionChanged += OnDirectionChanged;
            }
        }

        get => _character;
    }

    public override void _ExitTree()
    {
        if (GodotObject.IsInstanceValid(_character))
        {
            _character.DirectionChanged -= OnDirectionChanged;
        }
    }

    private void OnDirectionChanged(Vector2 direction)
    {
        if (direction.X == 0)
            return;

        Scale = new Vector2(Mathf.Abs(Scale.X) * (direction.X > 0 ? 1 : -1), Scale.Y);
    }

}
