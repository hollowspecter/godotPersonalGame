using Godot;
using System;

public class BackgroundScroller : Node2D
{
	private Sprite[] bgSprites;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var children = GetChildren();
		bgSprites = new Sprite[children.Count];
		for (int i = 0; i < bgSprites.Length; ++i)
		{
			bgSprites[i] = (Sprite)children[i];
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(float delta)
	// {

	// }

	private void _on_Area2D_area_exited(object area, int index)
	{
		bgSprites[index].Position += new Vector2(GetChildCount() * 512, 0f);
	}
}
