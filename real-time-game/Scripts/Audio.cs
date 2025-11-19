using Godot;
using System;

public partial class Audio : AudioStreamPlayer2D
{
	public override void _Ready()
	{
		this.Play();
	}
}
