using Godot;
using LanetliDeste;
using System;

public partial class Oyunbitti : Control
{

	private ColorRect colorrect;
	private Label label;
	private Button button;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		colorrect=GetNode<ColorRect>("ColorRect");
		label=GetNode<Label>("Label");
		button=GetNode<Button>("Button");

		label.Modulate=new Color(label.Modulate.R, label.Modulate.G, label.Modulate.B, 0.0f);
		button.Modulate=new Color(button.Modulate.R, button.Modulate.G, button.Modulate.B, 0.0f);

		ekranKarart();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ekranKarart()
	{
		Tween tween=CreateTween();
		tween.TweenProperty(colorrect,"modulate:a",1.0f,2.0f);
		tween.TweenProperty(label,"modulate:a",1.0f,1.5f);
		tween.TweenProperty(button,"modulate:a",1.0f,1.5f);
	}
	public void _on_button_pressed()
	{
		GameManager.gameon=true;
		GetTree().ChangeSceneToFile("res://Scenes/ana_menu.tscn");
	}
}
