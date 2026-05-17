using Godot;
using System;
using System.Reflection;

namespace LanetliDeste;
public partial class Silah : CharacterBody2D , IType
{
	[Export]public AnimatedSprite2D silah_anim;

	Player player=GameManager.playerglobal;

	private PanelContainer panel;
	private MarginContainer margin;
	private Label label;

	[Export] public int Value{get;set;}
	public string type;
	int index=GD.RandRange(0,GameManager.silah_value.Count-1);


	public Silah()
	{
		Value=GameManager.silah_value[index];
		SetType();
	}

	public override void _PhysicsProcess(double delta)
	{
		silah_anim.Play($"{type}");
	}

    public override void _Ready()
    {
        silah_anim=GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		panel=GetNode<PanelContainer>("PanelContainer");
		margin =panel.GetNode<MarginContainer>("MarginContainer");
		label= margin.GetNode<Label>("enem");
		label.Text="silah gücü:"+Value;
		panel.Visible=false;
    }

	public void SetType()
	{
		if (Value < 6)
		{
			type = Convert.ToString(GD.RandRange(1, 2));
		}
		else if(Value>=6 && Value < 8)
		{
			type = Convert.ToString(GD.RandRange(3, 4));
		}
		else
		{
			type = Convert.ToString(GD.RandRange(5, 6));
		}
		
	}
	public void _on_silah_pressed()
	{
		Interact(player);
		GameManager.etkilesim++;
	}

	public void Interact(Player player)
	{
			player.SilahKusan(Value);
			GameManager.silah_value.Remove(Value);
			silah_anim.Hide();
			panel.Visible=false;
	
		
	}

	public void _on_silah_mouse_entered()
	{
		panel.Visible=true;
	}

	public void _on_silah_mouse_exited()
	{
		panel.Visible=false;
	}
	
}
