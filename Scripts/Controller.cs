using Godot;
using System;

public class Controller : Godot.Area2D
{
	[Export]
	private float speed = 50;

	private AnimationTree animTree;
	private bool hiding;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animTree = GetNode<AnimationTree>(nameof(AnimationTree));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		hiding = Input.IsKeyPressed((int)KeyList.Space);
		animTree.Set("parameters/conditions/hiding", hiding);
		animTree.Set("parameters/conditions/unhiding", !hiding);

		if (hiding)
		{
			// do nothing?
		}
		else
		{
			Position += new Vector2(speed * delta, 0);
		}
	}
}
