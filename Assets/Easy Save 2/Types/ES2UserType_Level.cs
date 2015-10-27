
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_Level : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		Level data = (Level)obj;
		// Add your writer.Write calls here.
		writer.Write(data.LevelNum);
		writer.Write(data.LevelScene);
		writer.Write(data.LevelSceneNum);
		writer.Write(data.LevelLock);
		writer.Write(data.isCurrent);
		writer.Write(data.LevelTime);
		writer.Write(data.LevelStars);

	}
	
	public override object Read(ES2Reader reader)
	{
		Level data = new Level();
		// Add your reader.Read calls here and return your object.
		data.LevelNum = reader.Read<System.Int32>();
		data.LevelScene = reader.Read<System.Int32>();
		data.LevelSceneNum = reader.Read<System.Int32>();
		data.LevelLock = reader.Read<System.Boolean>();
		data.isCurrent = reader.Read<System.Boolean>();
		data.LevelTime = reader.Read<System.Int32>();
		data.LevelStars = reader.Read<System.Int32>();

		return data;
	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_Level():base(typeof(Level)){}
}
