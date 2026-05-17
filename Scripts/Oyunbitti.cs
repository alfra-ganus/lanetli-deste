using Godot;
using LanetliDeste;
using System;

public partial class Oyunbitti : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_pressed()
	{
		GameManager.gameon=true;
		GetTree().ChangeSceneToFile("res://Scenes/ana_menu.tscn");
	}
}
