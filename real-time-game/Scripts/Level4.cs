using Godot;
using System;

public partial class Level4 : LevelBase
{
	public override void NextLevel()
	{
		CallDeferred(nameof(LoadNextLevel));
	}

	private void LoadNextLevel()
	{
		var nextScene = ResourceLoader.Load<PackedScene>("res://scenes/level_5.tscn");
		GetTree().ChangeSceneToPacked(nextScene);
	}
}
