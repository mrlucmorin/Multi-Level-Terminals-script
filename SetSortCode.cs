public class MultiLevelSortCode
{
	[DeclareAction("SetSortCodeAction")]
	public void SetSortCodeAction()
	{
		//Use a Command Line Interpreter to call the Action
		CommandLineInterpreter CLI = new CommandLineInterpreter();

		Eplan.EplApi.Base.Settings set = new Eplan.EplApi.Base.Settings();
		if(!set.ExistSetting("USER.SCRIPTS.SORTCODE"))
		{
			bool bOk = set.AddNumericSetting("USER.SCRIPTS.SORTCODE",  new int[] { 0 },
				new Range[] { new Range { FromValue = 0, ToValue = 32768}}, "Sort code setting", new int[] { 0 },
				ISettings.CreationFlag.Insert);
		}
	
		int index = set.GetNumericSetting("USER.SCRIPTS.SORTCODE", 0);

		ActionCallingContext ctx1 = new ActionCallingContext();
		ctx1.AddParameter("propertyID","20809"); //Sort code
		ctx1.AddParameter("propertyIndex","0");
		ctx1.AddParameter("propertyValue", index.ToString());
		CLI.Execute("XEsSetPropertyAction", ctx1);

		set.SetNumericSetting("USER.SCRIPTS.SORTCODE", ++index, 0);

		return;

	}

	[DeclareMenu]
	public void SetSortCodeMenuFunction()
	{
		Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
		oMenu.AddMenuItem("Set sort code", "SetSortCodeAction");
	}

	[DeclareAction("ResetSortCodeAction")]
	public void ResetSortCodeAction()
	{
		//Use a Command Line Interpreter to call the Action
		CommandLineInterpreter CLI = new CommandLineInterpreter();

		Eplan.EplApi.Base.Settings set = new Eplan.EplApi.Base.Settings();
		if(!set.ExistSetting("USER.SCRIPTS.SORTCODE"))
		{
			bool bOk = set.AddNumericSetting("USER.SCRIPTS.SORTCODE",  new int[] { 0 },
				new Range[] { new Range { FromValue = 0, ToValue = 32768}}, "Sort code setting", new int[] { 0 },
				ISettings.CreationFlag.Insert);
		}

		set.SetNumericSetting("USER.SCRIPTS.SORTCODE", 0, 0);

		return;

	}

	[DeclareMenu]
	public void ResetSortCodeMenuFunction()
	{
		Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
		oMenu.AddMenuItem("Reset sort code", "ResetSortCodeAction");
	}

}