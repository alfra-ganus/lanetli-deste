using Godot;
using System;
using System.Collections.Generic;

namespace LanetliDeste;
public partial class GameManager
{
	private static GameManager _instance;
	public static GameManager Instance
	{
		get{
			if(_instance==null){
			_instance=new GameManager();
			_instance.Load();
			}
		return _instance;
		}
		
	}
	
	public static bool gameon=true;
	public static Player playerglobal;

	public static int canglobal;

	public static int silahglobal;

	public static Iksir iksirglobal;
	public static int zindan;
	public static int top_enemy=0;
	public static int top_iksir=0;
	public static int skor=0; //en son save öncesi skoru üst statlara göre hesaplatıcam

	public List<int> SkorGecmis { get; set; } = new List<int>();

	private string save_path= "user://game_stats.cfg";
	public static int etkilesim;

	public static float dbValueglobal;

	public static List<int> iksir_value=new List<int> {2,3,4,5,6,7,8,9,10};

	public static List<int> silah_value=new List<int> {2,3,4,5,6,7,8,9,10,11,12,13,14};

	public static List<int> enemy_value=new List<int> {2,3,4,5,6,7,8,9,10,11,12,13,14};

	public void YeniSkor()
	{
		skor=(top_enemy*5)+(top_iksir)+(zindan*10);
		SkorGecmis.Add(skor);
		Save();
	}

	public void Save()
	{
		ConfigFile config=new ConfigFile();

		config.SetValue("Gecmis","Skorlar",SkorGecmis.ToArray());
		
		Error err =config.Save(save_path);

		if (err == Error.Ok)
		{
			GD.Print("Veriler başarıyla kaydedildi");
		}
	}

	public void Load()
	{
		ConfigFile config=new ConfigFile();
		Error err= config.Load(save_path);

		if(err != Error.Ok)
		{
			return;
		}

		if (config.HasSectionKey("Gecmis", "Skorlar"))
		{
			int[] loadeddizi = (int[])config.GetValue("Gecmis","Skorlar");
			SkorGecmis= new List<int>(loadeddizi);
		}

	}

	public void Reset()
	{
		SkorGecmis.Clear();

		if (FileAccess.FileExists(save_path))
		{
			Error err= DirAccess.RemoveAbsolute(save_path);
			if (err == Error.Ok)
			{
				GD.Print("Geçmiş saveler silindi!");
			}
			else
			{
				GD.PrintErr($"Geçmiş saveler silinirken hata oluştu: {err}");
			}
		}
	}

}
