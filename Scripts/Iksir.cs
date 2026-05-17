using Godot;
using System;

namespace LanetliDeste;
public partial class Iksir : CharacterBody2D , IType
{
	private AnimatedSprite2D iksir_anim;
	Player player=GameManager.playerglobal;

	private PanelContainer panel;
	private MarginContainer margin;
	private Label label;
	[Export] public int Value {get;set;}

	public string type {get;set;}

	public bool Interactable {get;set;}=true;

	private int index=GD.RandRange(0,GameManager.iksir_value.Count-1);

	public Iksir()
	{
		Value=GameManager.iksir_value[index];
		SetType();
	}

	public void SetType()
	{
		if (Value < 6)
		{
			type = Convert.ToString(GD.RandRange(1, 2));
		}
		else
		{
			type = Convert.ToString(GD.RandRange(3, 4));
		}
	}

	public void Interact(Player player)
	{
		player.CanUpdate(Value,"iksir");
		GameManager.iksir_value.Remove(Value);
		iksir_anim.Hide();
		panel.Visible=false;
	}
	
	
	public void _on_iksir_pressed()
	{
		Interact(player);
		GameManager.etkilesim++;
	}

    public override void _Ready()
    {
		GameManager.iksirglobal=this;
        iksir_anim=GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		panel=GetNode<PanelContainer>("PanelContainer");
		margin =panel.GetNode<MarginContainer>("MarginContainer");
		label= margin.GetNode<Label>("enem");
		label.Text="iksir gücü:"+Value;
		panel.Visible=false;
		
    }

	public override void _PhysicsProcess(double delta)
	{
		iksir_anim.Play($"{type}");
	}

	public void _on_iksir_mouse_entered()
	{
		panel.Visible=true;
	}

	public void _on_iksir_mouse_exited()
	{
		panel.Visible=false;
	}
}
