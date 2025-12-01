using Godot;
using System;

public partial class GemCounter : CanvasLayer
{
	private Label waterLabel;
	private Label fireLabel;
	private Label neutralLabel;
	
	private int waterCount = 0;
	private int fireCount = 0;
	private int neutralCount = 0;
	
	public override void _Ready()
	{
		waterLabel = GetNode<Label>("WaterGems");
		fireLabel = GetNode<Label>("FireGems");
		neutralLabel = GetNode<Label>("NeutralGems");
		
		UpdateUI();
	}
	
	public void AddGem(GemKind type)
	{
		switch (type)
		{
			case GemKind.Water:
				waterCount++;
				break;
			case GemKind.Fire:
				fireCount++;
				break;
			case GemKind.Neutral:
				neutralCount++;
				break;
			default:
				GD.PrintErr($"Unknown gem type: {type}");
				break;
		}
		
		UpdateUI();
	}
	
	private void UpdateUI()
	{
		waterLabel.Text = $"Water: {waterCount}";
		fireLabel.Text = $"Fire: {fireCount}";
		neutralLabel.Text = $"Neutral: {neutralCount}";
	}
}
