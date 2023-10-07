#if TOOLS
using Godot;
using System;

[Tool]
public partial class plugin : EditorPlugin
{
	Button button;
	Container container;
	Control AssetWindow;
	PackedScene pkdScene = ResourceLoader.Load<PackedScene>("res://addons/AssetManager/main.tscn");
	Panel homePanelIns;

	
	public void ahhh()
	{
		//for python integration
	}
	
	private void onButtonPressed(){
		
		
		if (homePanelIns != null){
			GD.Print("lol");
			homePanelIns.Visible = ! homePanelIns.Visible;
			return;
		}

		var editorRoot = GetTree().Root;
		homePanelIns = (Panel)pkdScene.Instantiate();
		editorRoot.AddChild(homePanelIns);
		
	}
	
	public override void _MakeVisible(bool visible)
	{
		if (homePanelIns != null)
		{
			homePanelIns.Visible = visible;
		}
	}
	 
	public override void _EnterTree()
	{
		button = new Button();
		container = new Container();
		var editorRoot = GetTree().Root;
		
		var onButtonPressedCallable = new Callable(this, nameof(onButtonPressed));
		var ahhhCallable = new Callable(this, nameof(ahhh));
		
		button.Text = "OniChan_Yamete_kudasai";
		button.Connect("pressed", onButtonPressedCallable);
		button.Connect("pressed", ahhhCallable);
		container.SetPosition(new Vector2(1080,10));
		container.AddChild(button);
		editorRoot.AddChild(container);
		
	}

	public override void _ExitTree()
	{
		if(button != null){
			button.QueueFree();
		}
		if(container != null){
			container.QueueFree();
		}
		if(homePanelIns != null){
			homePanelIns.QueueFree();
		}
		
	}
}
#endif
