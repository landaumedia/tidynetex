using System;
	
/*
* Copyright (c) 2000 World Wide Web Consortium,
* (Massachusetts Institute of Technology, Institut National de
* Recherche en Informatique et en Automatique, Keio University). All
* Rights Reserved. This program is distributed under the W3C's Software
* Intellectual Property License. This program is distributed in the
* hope that it will be useful, but WITHOUT ANY WARRANTY; without even
* the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR
* PURPOSE.
* See W3C License http://www.w3.org/Consortium/Legal/ for more details.
*/
namespace TidyNet.Dom
{
	/// <summary> The <code>NodeList</code> interface provides the abstraction of an ordered 
	/// collection of nodes, without defining or constraining how this collection 
	/// is implemented. <code>NodeList</code> objects in the DOM are live.
	/// <br/>The items in the <code>NodeList</code> are accessible via an integral 
	/// index, starting from 0.
	/// <br/>See also the <a href='http://www.w3.org/TR/2000/REC-DOM-Level-2-Core-20001113'>Document Object Model (DOM) Level 2 Core Specification</a>.
	/// </summary>
	internal interface INodeList
	{
		/// <summary> The number of nodes in the list. The range of valid child node indices 
		/// is 0 to <code>length-1</code> inclusive. 
		/// </summary>
		int Length
		{
			get;
		}

		/// <summary> Returns the <code>index</code>th item in the collection. If 
		/// <code>index</code> is greater than or equal to the number of nodes in 
		/// the list, this returns <code>null</code>.
		/// </summary>
		/// <param name="indexIndex">into the collection.</param>
		/// <returns> The node at the <code>index</code>th position in the 
		/// <code>NodeList</code>, or <code>null</code> if that is not a valid 
		/// index.
		/// </returns>
		INode Item(int index);
	}
}