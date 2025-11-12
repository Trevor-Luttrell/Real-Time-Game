using Godot;
using System;

public enum HazardKind {Fire, Water, Acid}

public partial class HazardArea : Area2D
{	
	[Signal]
	public delegate void HazardTriggeredEventHandler();
	[Export]
	public HazardKind Kind = HazardKind.Water;
	
	private Sprite2D sprite;
	
	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
		SetVisual();
		BodyEntered += OnBodyEntered; 
	}
	
	private void SetVisual()
	{
		switch (Kind)
		{
			case HazardKind.Fire:
				sprite.Modulate = new Color(1f, 0.4f, 0.1f);
				break;
			case HazardKind.Water:
				sprite.Modulate = new Color(0.3f, 0.6f, 1f);
				break;
			case HazardKind.Acid:
				sprite.Modulate = new Color(0.6f, 1f, 0.3f);
				break;
		}
	}
	
	private void OnBodyEntered(Node2D body)
	{
		EmitSignal(SignalName.HazardTriggered);
	}
}
