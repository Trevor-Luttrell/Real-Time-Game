using Godot;
using System;

public partial class DisappearingPlatform : StaticBody2D
{
	private Timer _timer;
	private CollisionShape2D _collisionShape;

	public override void _Ready()
	{
		_timer = GetNode<Timer>("Area2D/Timer");
		_collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
	}

	private void _on_area_2d_body_entered(Node2D body)
	{
		if (body is CharacterBody2D)
		{
			_timer.Start();
		}
	}

	private void _on_timer_timeout()
	{
		var tween = CreateTween();
		tween.TweenProperty(this, "modulate:a", 0f, 0.4f);
		_collisionShape.Position = new Vector2(-10000, 20000);
	}
}
