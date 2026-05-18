using Godot;
using LanetliDeste;
using System;
using System.Text;

public partial class Skorlar : Control
{
	[Export] public Label istatistik;
	public override void _Ready()
	{

		if(istatistik != null)
		{
			StringBuilder sb=new StringBuilder();
			var gecmis=GameManager.Instance.SkorGecmis;
			if (gecmis.Count == 0)
			{
				sb.AppendLine("Henüz skorunuz yok");
			}
			else
			{
				for(int i = 0; i < gecmis.Count; i++)
				{
					sb.AppendLine($"{i+1}. {gecmis[i]} Puan");
				}
			}

			istatistik.Text=sb.ToString();
		}

		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/ana_menu.tscn");
	}
}
