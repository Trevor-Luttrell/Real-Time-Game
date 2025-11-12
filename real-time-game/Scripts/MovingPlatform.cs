using Godot;
using System;

public partial class MovingPlatform : Path2D
{
	[Export]
	public float speed = 100f;
	
	private PathFollow2D pathFollow;
	private CharacterBody2D platform;
	private float pathLength;
	private Curve2D curve;
	
	public override void _Ready()
	{
		pathFollow = GetNode<PathFollow2D>("PathFollow2D");
		platform = GetNode<CharacterBody2D>("CharacterBody2D");
		curve = this.Curve;
		
		pathLength = curve.GetBakedLength();
	}
	
	public override void _PhysicsProcess(double delta)
	{
		followPath(delta);
	}
	
	private void followPath(double delta)
	{
		pathFollow.ProgressRatio += (speed * (float)delta) / pathLength;
		pathFollow.ProgressRatio %= 1.0f;
		platform.GlobalPosition = pathFollow.GlobalPosition;
		
	}
}
