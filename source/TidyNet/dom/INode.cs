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
	/// <summary> The <code>Node</code> interface is the primary datatype for the entire 
	/// Document Object Model. It represents a single node in the document tree. 
	/// While all objects implementing the <code>Node</code> interface expose 
	/// methods for dealing with children, not all objects implementing the 
	/// <code>Node</code> interface may have children. For example, 
	/// <code>Text</code> nodes may not have children, and adding children to 
	/// such nodes results in a <code>DOMException</code> being raised.
	/// <br/>The attributes <code>nodeName</code>, <code>nodeValue</code> and 
	/// <code>attributes</code> are included as a mechanism to get at node 
	/// information without casting down to the specific derived interface. In 
	/// cases where there is no obvious mapping of these attributes for a 
	/// specific <code>nodeType</code> (e.g., <code>nodeValue</code> for an 
	/// <code>Element</code> or <code>attributes</code> for a <code>Comment</code>
	/// ), this returns <code>null</code>. Note that the specialized interfaces 
	/// may contain additional and more convenient mechanisms to get and set the 
	/// relevant information.
	/// <br/>See also the <a href='http://www.w3.org/TR/2000/REC-DOM-Level-2-Core-20001113'>Document Object Model (DOM) Level 2 Core Specification</a>.
	/// </summary>
	internal interface INode
	{
		/// <summary> The name of this node, depending on its type; see the table above.</summary>
		string NodeName
		{
			get;
		}

		/// <summary> The value of this node, depending on its type; see the table above. 
		/// When it is defined to be <code>null</code>, setting it has no effect.
		/// </summary>
		/// <exception cref="DOMException">
		/// NO_MODIFICATION_ALLOWED_ERR: Raised when the node is readonly.
		/// </exception>
		/// <exception cref="DOMException">
		/// DOMSTRING_SIZE_ERR: Raised when it would return more characters than 
		/// fit in a <code>DOMString</code> variable on the implementation 
		/// platform.
		/// </exception>
		string NodeValue
		{
			get;
			set;
		}

		/// <summary> A code representing the type of the underlying object, as defined above.</summary>
		NodeType NodeType
		{
			get;
		}

		/// <summary> The parent of this node. All nodes, except <code>Attr</code>, 
		/// <code>Document</code>, <code>DocumentFragment</code>, 
		/// <code>Entity</code>, and <code>Notation</code> may have a parent. 
		/// However, if a node has just been created and not yet added to the 
		/// tree, or if it has been removed from the tree, this is 
		/// <code>null</code>.
		/// </summary>
		INode ParentNode
		{
			get;
		}

		/// <summary> A <code>NodeList</code> that contains all children of this node. If 
		/// there are no children, this is a <code>NodeList</code> containing no 
		/// nodes.
		/// </summary>
		INodeList ChildNodes
		{
			get;
		}

		/// <summary> The first child of this node. If there is no such node, this returns 
		/// <code>null</code>.
		/// </summary>
		INode FirstChild
		{
			get;
		}

		/// <summary> The last child of this node. If there is no such node, this returns 
		/// <code>null</code>.
		/// </summary>
		INode LastChild
		{
			get;
		}

		/// <summary> The node immediately preceding this node. If there is no such node, 
		/// this returns <code>null</code>.
		/// </summary>
		INode PreviousSibling
		{
			get;
		}

		/// <summary> The node immediately following this node. If there is no such node, 
		/// this returns <code>null</code>.
		/// </summary>
		INode NextSibling
		{
			get;
		}

		/// <summary> A <code>NamedNodeMap</code> containing the attributes of this node (if 
		/// it is an <code>Element</code>) or <code>null</code> otherwise. 
		/// </summary>
		INamedNodeMap Attributes
		{
			get;
		}

		/// <summary> The <code>Document</code> object associated with this node. This is 
		/// also the <code>Document</code> object used to create new nodes. When 
		/// this node is a <code>Document</code> or a <code>DocumentType</code> 
		/// which is not used with any <code>Document</code> yet, this is 
		/// <code>null</code>.
		/// </summary>
		IDocument OwnerDocument
		{
			get;
		}

		/// <summary> The namespace URI of this node, or <code>null</code> if it is 
		/// unspecified.
		/// <br/>This is not a computed value that is the result of a namespace 
		/// lookup based on an examination of the namespace declarations in 
		/// scope. It is merely the namespace URI given at creation time.
		/// <br/>For nodes of any type other than <code>ELEMENT_NODE</code> and 
		/// <code>ATTRIBUTE_NODE</code> and nodes created with a DOM Level 1 
		/// method, such as <code>createElement</code> from the 
		/// <code>Document</code> interface, this is always <code>null</code>.Per 
		/// the Namespaces in XML Specification  an attribute does not inherit 
		/// its namespace from the element it is attached to. If an attribute is 
		/// not explicitly given a namespace, it simply has no namespace.
		/// </summary>
		string NamespaceURI
		{
			get;
		}

		/// <summary> The namespace prefix of this node, or <code>null</code> if it is 
		/// unspecified.
		/// <br/>Note that setting this attribute, when permitted, changes the 
		/// <code>nodeName</code> attribute, which holds the qualified name, as 
		/// well as the <code>tagName</code> and <code>name</code> attributes of 
		/// the <code>Element</code> and <code>Attr</code> interfaces, when 
		/// applicable.
		/// <br/>Note also that changing the prefix of an attribute that is known to 
		/// have a default value, does not make a new attribute with the default 
		/// value and the original prefix appear, since the 
		/// <code>namespaceURI</code> and <code>localName</code> do not change.
		/// <br/>For nodes of any type other than <code>ELEMENT_NODE</code> and 
		/// <code>ATTRIBUTE_NODE</code> and nodes created with a DOM Level 1 
		/// method, such as <code>createElement</code> from the 
		/// <code>Document</code> interface, this is always <code>null</code>.
		/// </summary>
		/// <exception cref="DOMException">
		/// INVALID_CHARACTER_ERR: Raised if the specified prefix contains an 
		/// illegal character.
		/// <br />NO_MODIFICATION_ALLOWED_ERR: Raised if this node is readonly.
		/// <br />NAMESPACE_ERR: Raised if the specified <code>prefix</code> is 
		/// malformed, if the <code>namespaceURI</code> of this node is 
		/// <code>null</code>, if the specified prefix is "xml" and the 
		/// <code>namespaceURI</code> of this node is different from "
		/// http://www.w3.org/XML/1998/namespace", if this node is an attribute 
		/// and the specified prefix is "xmlns" and the 
		/// <code>namespaceURI</code> of this node is different from "
		/// http://www.w3.org/2000/xmlns/", or if this node is an attribute and 
		/// the <code>qualifiedName</code> of this node is "xmlns" .
		/// </exception>
		string Prefix
		{
			get;
			set;
		}

		/// <summary> Returns the local part of the qualified name of this node.
		/// <br/>For nodes of any type other than <code>ELEMENT_NODE</code> and 
		/// <code>ATTRIBUTE_NODE</code> and nodes created with a DOM Level 1 
		/// method, such as <code>createElement</code> from the 
		/// <code>Document</code> interface, this is always <code>null</code>.
		/// </summary>
		string LocalName
		{
			get;
		}

		/// <summary> Inserts the node <code>newChild</code> before the existing child node 
		/// <code>refChild</code>. If <code>refChild</code> is <code>null</code>, 
		/// insert <code>newChild</code> at the end of the list of children.
		/// <br />If <code>newChild</code> is a <code>DocumentFragment</code> object, 
		/// all of its children are inserted, in the same order, before 
		/// <code>refChild</code>. If the <code>newChild</code> is already in the 
		/// tree, it is first removed.
		/// </summary>
		/// <param name="newChildThe">node to insert.</param>
		/// <param name="refChildThe">reference node, i.e., the node before which the new 
		/// node must be inserted.</param>
		/// <returns>The node being inserted.</returns>
		/// <exception cref="DOMException">
		/// HIERARCHY_REQUEST_ERR: Raised if this node is of a type that does not 
		/// allow children of the type of the <code>newChild</code> node, or if 
		/// the node to insert is one of this node's ancestors.
		/// <br />WRONG_DOCUMENT_ERR: Raised if <code>newChild</code> was created 
		/// from a different document than the one that created this node.
		/// <br />NO_MODIFICATION_ALLOWED_ERR: Raised if this node is readonly or 
		/// if the parent of the node being inserted is readonly.
		/// <br />NOT_FOUND_ERR: Raised if <code>refChild</code> is not a child of 
		/// this node.
		/// </exception>
		INode InsertBefore(INode newChild, INode refChild);
		
		/// <summary> Replaces the child node <code>oldChild</code> with <code>newChild</code>
		/// in the list of children, and returns the <code>oldChild</code> node.
		/// <br/>If <code>newChild</code> is a <code>DocumentFragment</code> object, 
		/// <code>oldChild</code> is replaced by all of the 
		/// <code>DocumentFragment</code> children, which are inserted in the 
		/// same order. If the <code>newChild</code> is already in the tree, it 
		/// is first removed.
		/// </summary>
		/// <param name="newChildThe">new node to put in the child list.</param>
		/// <param name="oldChildThe">node being replaced in the list.</param>
		/// <returns>The node replaced.</returns>
		/// <exception cref="DOMException">
		/// HIERARCHY_REQUEST_ERR: Raised if this node is of a type that does not 
		/// allow children of the type of the <code>newChild</code> node, or if 
		/// the node to put in is one of this node's ancestors.
		/// <br />WRONG_DOCUMENT_ERR: Raised if <code>newChild</code> was created 
		/// from a different document than the one that created this node.
		/// <br />NO_MODIFICATION_ALLOWED_ERR: Raised if this node or the parent of 
		/// the new node is readonly.
		/// <br />NOT_FOUND_ERR: Raised if <code>oldChild</code> is not a child of 
		/// this node.
		/// </exception>
		INode ReplaceChild(INode newChild, INode oldChild);
		
		/// <summary> Removes the child node indicated by <code>oldChild</code> from the list 
		/// of children, and returns it.
		/// </summary>
		/// <param name="oldChildThe">node being removed.</param>
		/// <returns>The node removed.</returns>
		/// <exception cref="DOMException">
		/// NO_MODIFICATION_ALLOWED_ERR: Raised if this node is readonly.
		/// <br />NOT_FOUND_ERR: Raised if <code>oldChild</code> is not a child of 
		/// this node.
		/// </exception>
		INode RemoveChild(INode oldChild);
		
		/// <summary> Adds the node <code>newChild</code> to the end of the list of children 
		/// of this node. If the <code>newChild</code> is already in the tree, it 
		/// is first removed.
		/// </summary>
		/// <param name="newChildThe">node to add.If it is a <code>DocumentFragment</code>
		/// object, the entire contents of the document fragment are moved 
		/// into the child list of this node
		/// </param>
		/// <returns>The node added.</returns>
		/// <exception cref="DOMException">
		/// HIERARCHY_REQUEST_ERR: Raised if this node is of a type that does not 
		/// allow children of the type of the <code>newChild</code> node, or if 
		/// the node to append is one of this node's ancestors.
		/// <br />WRONG_DOCUMENT_ERR: Raised if <code>newChild</code> was created 
		/// from a different document than the one that created this node.
		/// <br />NO_MODIFICATION_ALLOWED_ERR: Raised if this node is readonly.
		/// </exception>
		INode AppendChild(INode newChild);
		
		/// <summary> Returns whether this node has any children.</summary>
		/// <returns>  <code>true</code> if this node has any children, 
		/// <code>false</code> otherwise.
		/// </returns>
		bool HasChildNodes();
		
		/// <summary> Returns a duplicate of this node, i.e., serves as a generic copy 
		/// constructor for nodes. The duplicate node has no parent; (
		/// <code>parentNode</code> is <code>null</code>.).
		/// <br/>Cloning an <code>Element</code> copies all attributes and their 
		/// values, including those generated by the XML processor to represent 
		/// defaulted attributes, but this method does not copy any text it 
		/// contains unless it is a deep clone, since the text is contained in a 
		/// child <code>Text</code> node. Cloning an <code>Attribute</code> 
		/// directly, as opposed to be cloned as part of an <code>Element</code> 
		/// cloning operation, returns a specified attribute (
		/// <code>specified</code> is <code>true</code>). Cloning any other type 
		/// of node simply returns a copy of this node.
		/// <br/>Note that cloning an immutable subtree results in a mutable copy, 
		/// but the children of an <code>EntityReference</code> clone are readonly
		/// . In addition, clones of unspecified <code>Attr</code> nodes are 
		/// specified. And, cloning <code>Document</code>, 
		/// <code>DocumentType</code>, <code>Entity</code>, and 
		/// <code>Notation</code> nodes is implementation dependent.
		/// </summary>
		/// <param name="deepIf"><code>true</code>, recursively clone the subtree under 
		/// the specified node; if <code>false</code>, clone only the node 
		/// itself (and its attributes, if it is an <code>Element</code>). 
		/// </param>
		/// <returns> The duplicate node.</returns>
		INode CloneNode(bool deep);
		
		/// <summary> Puts all <code>Text</code> nodes in the full depth of the sub-tree 
		/// underneath this <code>Node</code>, including attribute nodes, into a 
		/// "normal" form where only structure (e.g., elements, comments, 
		/// processing instructions, CDATA sections, and entity references) 
		/// separates <code>Text</code> nodes, i.e., there are neither adjacent 
		/// <code>Text</code> nodes nor empty <code>Text</code> nodes. This can 
		/// be used to ensure that the DOM view of a document is the same as if 
		/// it were saved and re-loaded, and is useful when operations (such as 
		/// XPointer  lookups) that depend on a particular document tree 
		/// structure are to be used.In cases where the document contains 
		/// <code>CDATASections</code>, the normalize operation alone may not be 
		/// sufficient, since XPointers do not differentiate between 
		/// <code>Text</code> nodes and <code>CDATASection</code> nodes.
		/// </summary>
		void Normalize();
		
		/// <summary> Tests whether the DOM implementation implements a specific feature and 
		/// that feature is supported by this node.
		/// </summary>
		/// <param name="featureThe">name of the feature to test. This is the same name 
		/// which can be passed to the method <code>hasFeature</code> on 
		/// <code>DOMImplementation</code>.
		/// </param>
		/// <param name="versionThis">is the version number of the feature to test. In 
		/// Level 2, version 1, this is the string "2.0". If the version is not 
		/// specified, supporting any version of the feature will cause the 
		/// method to return <code>true</code>.
		/// </param>
		/// <returns> Returns <code>true</code> if the specified feature is 
		/// supported on this node, <code>false</code> otherwise.
		/// </returns>
		bool IsSupported(string feature, string version);
		
		/// <summary> Returns whether this node (if it is an element) has any attributes.</summary>
		/// <returns> <code>true</code> if this node has any attributes, 
		/// <code>false</code> otherwise.
		/// </returns>
		bool HasAttributes();
	}
}