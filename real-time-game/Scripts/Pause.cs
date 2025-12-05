using Godot;
using System;

public partial class Pause : CanvasLayer
{
	private ColorRect colorRect;
	
	public override void _Ready()
	{
		colorRect = GetNode<ColorRect>("ColorRect");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		if(Input.IsActionJustPressed("pause"))
		{
			GetTree().Paused = !GetTree().Paused;
			colorRect.Visible = !colorRect.Visible;
		}
	}
}
