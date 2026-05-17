using Godot;
using System;
using System.ComponentModel;
using System.Reflection;

namespace LanetliDeste;
public partial class Enemy : CharacterBody2D , IType
{
	private AnimatedSprite2D enemy_anim;
	private PanelContainer panel;
	private MarginContainer margin;
	private Label label;

	Player player=GameManager.playerglobal;
	public string type {get;set;}
	[Export]public int Value;

	private int index=GD.RandRange(0,GameManager.enemy_value.Count-1);
	public Enemy(){
		Value=GameManager.enemy_value[index];
		SetType();
	}
	public override void _PhysicsProcess(double delta)
	{
		enemy_anim.Play($"{type}");

	}

	public override void _Ready(){
		enemy_anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		panel=GetNode<PanelContainer>("PanelContainer");
		margin =panel.GetNode<MarginContainer>("MarginContainer");
		label= margin.GetNode<Label>("enem");
		label.Text="düşman gücü:"+Value;
		panel.Visible=false;
		
	}
	public void SetType()
	{
		if (Value < 5)
		{
			type = Convert.ToString(GD.RandRange(1, 2));
		}
		else if(Value>=5 && Value < 10)
		{
			type = Convert.ToString(GD.RandRange(3, 4));
		}
		else
		{
			type = Convert.ToString(GD.RandRange(5, 6));
		}
		
	}

	public void Interact(Player player)
	{
		player.CanUpdate(Value,"enemy");
		GameManager.enemy_value.Remove(Value);
		enemy_anim.Hide();
		panel.Visible=false;

	}

	public void _on_enemy_pressed()
	{
		Interact(player);
		GameManager.etkilesim++;
	}

	public void _on_enemy_mouse_entered()
	{
		panel.Visible=true;
	}

	public void _on_enemy_mouse_exited()
	{
		panel.Visible=false;
	}
	

}
