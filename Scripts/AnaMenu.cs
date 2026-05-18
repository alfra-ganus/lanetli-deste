using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LanetliDeste;


public partial class AnaMenu : Control
{
	private static AudioStreamPlayer a;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		a=GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		int busIndex = AudioServer.GetBusIndex("Master");
		AudioServer.SetBusVolumeDb(busIndex,GameManager.dbValueglobal);
	}
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GameManager.canglobal=20;
		GameManager.silahglobal=0;
		GameManager.etkilesim=0;
		GameManager.zindan=1;
		GameManager.gameon=true;
	}

	public void _on_start_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/dünya_1.tscn");
	}

	public void _on_options_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/ayarlar.tscn");
	}

	public void _on_skor_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/skorlar.tscn");
	}

	public void _on_rehber_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/oyunrehberi.tscn");
	}

	public void _on_tasarım_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/tasarımlar.tscn");
	}
}
