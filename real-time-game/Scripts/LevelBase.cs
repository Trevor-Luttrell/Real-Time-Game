using Godot;
using System;

public partial class LevelBase : Node2D
{
	[Export]
	public Vector2 WatergirlStartPos;
	[Export]
	public Vector2 FireboyStartPos;
	
	private Watergirl watergirl;
	private Fireboy fireboy;
	private Node2D hazards;
	
	public override void _Ready()
	{
		watergirl = GetNode<Watergirl>("Watergirl");
		WatergirlStartPos = watergirl.GlobalPosition;
		fireboy = GetNode<Fireboy>("Fireboy");
		FireboyStartPos = fireboy.GlobalPosition;
		
		hazards = GetNode<Node2D>("Hazards");
		
		foreach (HazardArea hazard in hazards.GetChildren())
		{
			hazard.HazardTriggered += OnHazardDeathTriggered;
		}
	}
		
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("restart"))
		{
			RestartLevel();
		}
	}
	
	public void OnHazardDeathTriggered()
	{
		CallDeferred(nameof(RestartLevel));
	}
	
	private void RestartLevel()
	{
		GetTree().ReloadCurrentScene();
	}
}
