using Godot;
using System;

public class TextCollider : Area2D
{
	[Export]
	private string text = "";

	// Called when the node enters the scene tree for the first time.
	// public override void _Ready()
	// {
	// }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(float delta)
	// {

	// }

	private void _on_TextCollider_area_entered(Area2D area)
	{
		GetTree().CallGroup("TextBox", "ShowText", text);
		QueueFree();
	}
}
