﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;
//using UnityEditor;
using System.Xml;
using System.IO;
using System.Text;
public class FileManager:SingleTon<FileManager>
{
	private static FileManager  _fm;
	private WWW www;
	
	private XmlDocument _doc;
	private XmlNode root;
	//	    private string _destFileName;
	
	/// 复制文件
	public void CopyFile (string srcFileName, string destFileName)
	{
		//		_destFileName = string.Copy(destFileName);
		#if UNITY_ANDROID
		Debug.Log("UNITY_ANDROID");
		StartCoroutine(StartCopyFile(srcFileName,destFileName));
		#else
		if (IsFileExists (srcFileName) && !srcFileName.Equals (destFileName)) {
			int index = destFileName.LastIndexOf ("/");
			//				Debug.Log(index);
			string filePath = string.Empty;
			
			if (index != -1) {
				//有
				filePath = destFileName.Substring (0, index);
				
			}
			
			if (!Directory.Exists (filePath)) {
				Debug.Log("==========");
				//目录不存在，创建一个新的目录
				Directory.CreateDirectory (filePath);
			}
			//将源文件内容拷贝到目标文件夹中
			File.Copy (srcFileName,destFileName, true);		
			//				AssetDatabase.Refresh ();
		}
		#endif	
		
	}	
	/// 检测文件是否存在于某个目录下
	public bool IsFileExists (string fileName)
	{
		if (fileName.Equals (string.Empty)) {
			return false;
		}
		return File.Exists (fileName);
	}
	//在StreamingAssets目录下，如果是安卓平台需要用WWW去读取srcPath中的内容
	IEnumerator StartCopyFile(string srcPath,string directPath)
	{
		www =  new WWW (srcPath);
		yield return www;
		if (string.IsNullOrEmpty(www.error)) {
			File.WriteAllText(directPath,www.text);
		}
		yield break;
	}
	
	public void ParseLevelsConfigXMLFile(string filePath)
	{


		StartCoroutine (StartConfigLevelsWithXML(filePath));
	}
	//保存当前进度  并且开启下一关
	public void SaveCurrentLevel(string currentLevel,int gotStarNumber)
	{
		
		//修改节点信息  假如是Level1  =>
		//1   找到Level节点 然后Number为1的 Star，然后修改Star字段的innerText
		//2   找到当前Level的下一个Level，并解锁之(就是修改   下一个  Level的Lock值)
		
		//subString =当前关卡
		string subString = currentLevel.Substring (5);//int.Parth(subString)+1
		int levelIndex = int.Parse (subString) - 1;
		int currentGotStarNumber = LevelConfig.GetInstance ().levelsConfig [levelIndex].star;
		LevelConfig.GetInstance ().levelsConfig [levelIndex].star= currentGotStarNumber<gotStarNumber?gotStarNumber:currentGotStarNumber;
		LevelConfig.GetInstance ().levelsConfig [levelIndex+1].isLock = false;
		
		string nextSubString = (levelIndex + 2).ToString ();
		
		//1 
		ChangeElement (subString,"Star",levelIndex);
		//2
		ChangeElement (nextSubString,"Lock",levelIndex+1);
		
		//		Debug.Log (FileMamager.GetInstance()._destFileName);
		
		_doc.Save (Application.persistentDataPath+"/"+"LevelConfig.xml");
	}
	
	void  ChangeElement(string levelNumer,string elementName,int levelIndex)
	{
		foreach(XmlElement ele in root)
		{
			//childEle => Number/Lock/Star
			foreach(XmlElement childEle in ele){
				
				if(childEle.Name.Equals("Number"))
				{
					if(!childEle.InnerText.Equals(levelNumer))break;
				}
				
				if(childEle.Name.Equals(elementName)){
					switch(elementName)
					{
					case "Star":
						childEle.InnerText = LevelConfig.GetInstance ().levelsConfig [levelIndex].star.ToString();
						break;
					case "Lock":
						int islock = LevelConfig.GetInstance ().levelsConfig [levelIndex].isLock?1:0;
						childEle.InnerText =  islock.ToString();
						break;
					default:
						break;
					}
				}
			}
		}
	}

	IEnumerator StartConfigLevelsWithXML(string filePath)
	{
		//XML 解析
		//1 工厂
		_doc = new XmlDocument ();

		//安卓设备上有问题！
		//		_doc.LoadXml (File.ReadAllText(filePath));
		_doc.Load (filePath);
		//2 获取根节点
		//root =>LevelConfig
		root = _doc.SelectSingleNode ("LevelConfig");
		
		//3  遍历
		//ele => Level
//		Global_Game.content = File.ReadAllText(filePath);
		
		foreach (XmlElement ele in root) {
			int number = 0;
			bool isLock = false;
			int starN = 0;
			int timeN = 0;
			int targetSc= 0;
			foreach(XmlElement childEle in ele)
			{
				switch(childEle.Name)
				{
					
				case "Number":
					number = int.Parse(childEle.InnerText);
					break;
				case "Lock":
					isLock = childEle.InnerText.Equals("0")?false:true;
					break;
				case "Star":
					starN = int.Parse(childEle.InnerText);
					break;
				case "Time":
					timeN = int.Parse(childEle.InnerText);
					break;
				case "TargetScore":
					targetSc = int.Parse(childEle.InnerText);
					break;
				default:
					break;
				}
				
			}
			Level aNewLevel = new Level(number,isLock,starN,timeN,targetSc);
			LevelConfig.GetInstance().levelsConfig.Add(aNewLevel);
		}
		yield break;
	}
	
}

