using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LanetliDeste;

public static class GameManager
{
	public static bool gameon=true;
	public static Player playerglobal;

	public static int canglobal;

	public static int silahglobal;

	public static Iksir iksirglobal;
	public static int zindan;

	public static int etkilesim;

	public static List<int> iksir_value=new List<int> {2,3,4,5,6,7,8,9,10};

	public static List<int> silah_value=new List<int> {2,3,4,5,6,7,8,9,10,11,12,13,14};

	public static List<int> enemy_value=new List<int> {2,3,4,5,6,7,8,9,10,11,12,13,14};

}
public partial class AnaMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		
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
