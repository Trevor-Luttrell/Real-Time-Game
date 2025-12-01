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
	private Node2D gems;
	
	public override void _Ready()
	{
		watergirl = GetNode<Watergirl>("Watergirl");
		WatergirlStartPos = watergirl.GlobalPosition;
		fireboy = GetNode<Fireboy>("Fireboy");
		FireboyStartPos = fireboy.GlobalPosition;
		
		hazards = GetNode<Node2D>("Hazards");
		gems = GetNode<Node2D>("Gems");
		
		foreach(HazardArea hazard in hazards.GetChildren())
		{
			hazard.HazardTriggered += OnHazardDeathTriggered;
		}
		
		foreach(Gem gem in gems.GetChildren())
		{
			gem.GemTriggered += OnGemTriggered;
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
	
	public void OnGemTriggered(Gem gem)
	{
		gem.QueueFree();
		GD.Print("Give Gem on Counter");
	}
	
	private void RestartLevel()
	{
		GetTree().ReloadCurrentScene();
	}
}
