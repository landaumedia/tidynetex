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
	/// <summary> This interface represents an entity, either parsed or unparsed, in an XML 
	/// document. Note that this models the entity itself not the entity 
	/// declaration. <code>Entity</code> declaration modeling has been left for a 
	/// later Level of the DOM specification.
	/// <br/>The <code>nodeName</code> attribute that is inherited from 
	/// <code>Node</code> contains the name of the entity.
	/// <br/>An XML processor may choose to completely expand entities before the 
	/// structure model is passed to the DOM; in this case there will be no 
	/// <code>EntityReference</code> nodes in the document tree.
	/// <br/>XML does not mandate that a non-validating XML processor read and 
	/// process entity declarations made in the external subset or declared in 
	/// external parameter entities. This means that parsed entities declared in 
	/// the external subset need not be expanded by some classes of applications, 
	/// and that the replacement value of the entity may not be available. When 
	/// the replacement value is available, the corresponding <code>Entity</code> 
	/// node's child list represents the structure of that replacement text. 
	/// Otherwise, the child list is empty.
	/// <br/>The DOM Level 2 does not support editing <code>Entity</code> nodes; if a 
	/// user wants to make changes to the contents of an <code>Entity</code>, 
	/// every related <code>EntityReference</code> node has to be replaced in the 
	/// structure model by a clone of the <code>Entity</code>'s contents, and 
	/// then the desired changes must be made to each of those clones instead. 
	/// <code>Entity</code> nodes and all their descendants are readonly.
	/// <br/>An <code>Entity</code> node does not have any parent.If the entity 
	/// contains an unbound namespace prefix, the <code>namespaceURI</code> of 
	/// the corresponding node in the <code>Entity</code> node subtree is 
	/// <code>null</code>. The same is true for <code>EntityReference</code> 
	/// nodes that refer to this entity, when they are created using the 
	/// <code>createEntityReference</code> method of the <code>Document</code> 
	/// interface. The DOM Level 2 does not support any mechanism to resolve 
	/// namespace prefixes.
	/// <br/>See also the <a href='http://www.w3.org/TR/2000/REC-DOM-Level-2-Core-20001113'>Document Object Model (DOM) Level 2 Core Specification</a>.
	/// </summary>
	internal interface IEntity : INode
	{
		/// <summary> The public identifier associated with the entity, if specified. If the 
		/// public identifier was not specified, this is <code>null</code>.
		/// </summary>
		string PublicId
		{
			get;
		}

		/// <summary> The system identifier associated with the entity, if specified. If the 
		/// system identifier was not specified, this is <code>null</code>.
		/// </summary>
		string SystemId
		{
			get;
		}

		/// <summary> For unparsed entities, the name of the notation for the entity. For 
		/// parsed entities, this is <code>null</code>. 
		/// </summary>
		string NotationName
		{
			get;
		}
	}
}