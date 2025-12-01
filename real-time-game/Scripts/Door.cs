using Godot;
using System;

public enum DoorKind {Fire, Water};

public partial class Door : Area2D
{
	[Signal]
	public delegate void DoorEnteredEventHandler(Door door);
	[Export]
	public DoorKind Kind = DoorKind.Fire;
	
	private AnimatedSprite2D sprite;
	
	public override void _Ready()
	{
		sprite = GetNode<AnimatedSprite2D>("Sprite2D");
		SetVisual();
		BodyEntered += OnBodyEntered; 
	}
	
	private void SetVisual()
	{
		switch(Kind)
		{
			case DoorKind.Fire:
				sprite.Modulate = new Color(1f, 0.4f, 0.1f);
				break;
			case DoorKind.Water:
				sprite.Modulate = new Color(0.3f, 0.6f, 1f);
				break;
		}
	}
	
	private void OnBodyEntered(Node2D body)
	{
		if(Kind == DoorKind.Water && body is Watergirl)
		{
			EnteredAnimation();
			EmitSignal(SignalName.DoorEntered, this);
		}
		else if(Kind == DoorKind.Fire && body is Fireboy)
		{
			EnteredAnimation();
			EmitSignal(SignalName.DoorEntered, this);
		}
	}
	
	private async void EnteredAnimation()
	{
		sprite.Play("opening");
		await ToSignal(sprite, "animation_finished");
		sprite.Play("closing");
		await ToSignal(sprite, "animation_finished");
		sprite.Play("default");
	}
}
