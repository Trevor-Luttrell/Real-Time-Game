using Godot;
using System;

public partial class Level8 : LevelBase
{
	public override void NextLevel()
	{
		CallDeferred(nameof(LoadNextLevel));
	}

	private void LoadNextLevel()
	{
		var nextScene = ResourceLoader.Load<PackedScene>("res://scenes/level_win.tscn");
		GetTree().ChangeSceneToPacked(nextScene);
	}
}
