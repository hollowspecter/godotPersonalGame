using Godot;
using System;

public class TextBox : Control
{
	[Export] private float timePerCharacter = 0.01f;
	[Export] private float waitTimeAfterDialogue = 2f;

	[Signal] public delegate void OnTextEnd();

	private RichTextLabel label;
	private Tween tween;
	private Timer timer;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		label = GetNode<RichTextLabel>(nameof(RichTextLabel));
		label.BbcodeText = "";
		tween = new Tween();
		AddChild(tween);
		timer = new Timer();
		AddChild(timer);
		timer.WaitTime = waitTimeAfterDialogue;
		timer.OneShot = true;
		timer.Connect("timeout", this, nameof(_on_Timer_timeout));
	}

	public void ShowText(string _message)
	{
		label.PercentVisible = 0f;
		label.BbcodeText = "[center]" + _message + "[/center]";
		var duration = _message.Length * timePerCharacter;
		tween.InterpolateProperty(label, "percent_visible", null, 1f, duration);
		tween.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		// var input = Input.IsKeyPressed((int)KeyList.Up);

		// if (label.Text.Length > 0 &&
		//     label.PercentVisible <= 0.99f &&
		//     input)
		// {
		//     tween.Stop(label, "percent_visible");
		//     label.PercentVisible = 1f;
		// }
		// else if (label.PercentVisible > 0.99f &&
		//          input)
		// {
		//     Done();
		// }

		if (Input.IsKeyPressed((int)KeyList.D))
			ShowText("TEST TEST 123");

		if (label.BbcodeText.Length > 0 &&
			label.PercentVisible > 0.99f &&
			timer.IsStopped())
		{
			timer.Start();
		}
	}

	private void Done()
	{
		label.BbcodeText = "";
		EmitSignal(nameof(OnTextEnd));
	}

	private void _on_Timer_timeout()
	{
		Done();
	}
}
