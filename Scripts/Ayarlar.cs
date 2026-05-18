using Godot;
using LanetliDeste;
using System;

namespace LanetliDeste;
public partial class Ayarlar : Control
{
	// Called when the node enters the scene tree for the first time.

	private HSlider hslide;
	[Export] public Label istatistik;
	public override void _Ready()
	{
		hslide=GetNode<HSlider>("ses");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void value_changed(double value)
	{
		int busIndex = AudioServer.GetBusIndex("Master");
		GameManager.dbValueglobal=Mathf.LinearToDb((float)value);//bu işlem için Mathf metodunun gerektiği ai yardımıyla bulunmuştur.
		AudioServer.SetBusVolumeDb(busIndex,GameManager.dbValueglobal);
	}

	public void _on_geri_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/ana_menu.tscn");
	}

	public void _on_reset_pressed()
	{
		GameManager.Instance.Reset();
	}

	

	public void _on_ses_drag_started()
	{}
		public void _on_ekran_toggled(bool ekran_pressed)
		{
		if (ekran_pressed)
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
		}
		else
		{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
		}
	
	}
}
