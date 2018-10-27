using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MapJSon 
{
	public List<ColumnListClass> columnClass;

	[Serializable]
	public class ColumnListClass
	{
		public List<int> columnList; 

		public ColumnListClass(List<int> gotColumnList){ 
			columnList = gotColumnList;
		}	

	}

}