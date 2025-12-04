using Godot;
using System;

public partial class Level1 : LevelBase
{
	public override void NextLevel()
	{
		CallDeferred(nameof(LoadNextLevel));
	}

	private void LoadNextLevel()
	{
		var nextScene = ResourceLoader.Load<PackedScene>("res://scenes/level_2.tscn");
		GetTree().ChangeSceneToPacked(nextScene);
	}
}
