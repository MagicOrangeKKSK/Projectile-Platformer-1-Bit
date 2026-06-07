using Godot;
using System;

public partial class PlatformerCharacter2D : CharacterBody2D
{
    public event Action<Vector2> DirectionChanged;

    private Vector2 _direction;
    public Vector2 direction
    {
        get => _direction;
        set
        {
            if (_direction != value)
            {
                _direction = value;
                DirectionChanged?.Invoke(_direction);
            }
        }
    }


}
