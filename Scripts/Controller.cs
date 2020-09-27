using Godot;
using System;

public class Controller : Godot.Area2D
{
	[Export]
	private float speed = 50;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		Position += new Vector2(speed * delta, 0);

		// if (Input.IsKeyPressed((int)KeyList.W))
		// {
		//     Position += new Vector2(0, -speed * delta);
		// }

		// if (Input.IsKeyPressed((int)KeyList.S))
		// {
		//     Position += new Vector2(0, speed * delta);
		// }

		// if (Input.IsKeyPressed((int)KeyList.A))
		// {
		//     Position += new Vector2(-speed * delta, 0);
		// }

		// if (Input.IsKeyPressed((int)KeyList.D))
		// {
		//     Position += new Vector2(speed * delta, 0);
		// }
	}
}
