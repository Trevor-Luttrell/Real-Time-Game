using Godot;
using System;

public enum GemKind {Fire, Water, Neutral}

public partial class Gem : Area2D
{	
	[Signal]
	public delegate void GemTriggeredEventHandler(Gem gem);
	[Export]
	public GemKind Kind = GemKind.Neutral;
	
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
			case GemKind.Fire:
				sprite.Modulate = new Color(1f, 0.4f, 0.1f);
				break;
			case GemKind.Water:
				sprite.Modulate = new Color(0.3f, 0.6f, 1f);
				break;
			case GemKind.Neutral:
				sprite.Modulate = new Color(0.6f, 0.6f, 0.6f);
				break;
		}
	}
	
	private void OnBodyEntered(Node2D body)
	{
		if(Kind == GemKind.Water && body is Watergirl)
			EmitSignal(SignalName.GemTriggered, this);
		else if(Kind == GemKind.Fire && body is Fireboy)
			EmitSignal(SignalName.GemTriggered, this);
		else if(Kind == GemKind.Neutral)
			EmitSignal(SignalName.GemTriggered, this);
	}
}
