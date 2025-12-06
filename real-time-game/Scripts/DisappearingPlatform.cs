using Godot;
using System;

public partial class DisappearingPlatform : StaticBody2D
{
	private Timer timer;
	private CollisionShape2D collisionShape2D;

	public override void _Ready()
	{
		timer = GetNode<Timer>("Area2D/CollisionShape2D/Timer");

		collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
	}

	private void _on_area_2d_body_entered(Node2D body)
	{
		if (body is CharacterBody2D)
		{
			timer.Start();
		}
	}

	private void _on_timer_timeout()
	{
		var tween = CreateTween();
		tween.TweenProperty(this, "modulate:a", 0.0f, 0.4f);

		collisionShape2D.Position = new Vector2(-10000, 20000);
	}
}
