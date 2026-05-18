using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LanetliDeste;


public interface IType
{
	void SetType();

	void Interact(Player player);

}

public partial class Dünya1 : Node2D 
{

	
	// Called when the node enters the scene tree for the first time.
	private Player player;
	private Label silah_deger;
	private Label can_deger;
	
	public override void _Ready()
	{
		Scale = new Vector2(6f, 6f);
		
		player=GetNode<Player>("player");
		GetNode<Spawner>("Spawner").Show();
		silah_deger=GetNode<Label>("silah_deger");
		can_deger=GetNode<Label>("can_deger");
		can_deger.Text=$"{GameManager.canglobal}";
	}

	
	public override void _Process(double delta)
	{
		if (GameManager.silahglobal != 0 )
		{
			silah_deger.Visible=true;
			silah_deger.Text=$"{GameManager.silahglobal}";
		}
		if (GameManager.silahglobal == 0)
		{
			silah_deger.Visible=false;
		}

		if (GameManager.canglobal != 0)
		{
			can_deger.Text=$"{GameManager.canglobal}";
		}
		
		if (GameManager.etkilesim == 3)
		{
			GetNode<Button>("key").Show();
			GetNode<Spawner>("Spawner").Hide();
		}
		else
		{
			GetNode<Button>("key").Hide();
		}

		if(GameManager.gameon==false){
			GameManager.Instance.YeniSkor();
			GetTree().ChangeSceneToFile("res://Scenes/kazandın.tscn");
		}
	}

	public void _on_button_pressed()
	{
			GetTree().ChangeSceneToFile("res://Scenes/ana_menu.tscn");
			//save

		
	}
	public void _on_key_pressed()
	{
		//diğer dungeona geçiş
		if (GameManager.gameon==true)
		{
			GameManager.zindan++;
			GameManager.etkilesim=0;
			GetTree().ChangeSceneToFile("res://Scenes/dünya_1.tscn");
		}
		
	}


}
