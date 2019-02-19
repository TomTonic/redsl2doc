using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace org.redsl.Compiler
{
    public static class Phase3
    {
        private const string DefaultRequiremtsPackageName = "General Requirements";

        public static XDocument PropagateFileAttributes(XDocument doc)
        {
            Util.CheckGen(doc, "1.0", "2");
            XDocument result = new XDocument(doc);
            Util.SetGen(result, "1.0", "2.1");
            IEnumerable<XElement> reqdeclNodes =
                from AnyElement in result.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("RequirementDecl")))
                    )
                select AnyElement;

            foreach (XElement node in reqdeclNodes)
            {
                PropagateFileAttribute(node);
            }
            return result;
        }

        private static void PropagateFileAttribute(XElement node)
        {
            XElement parentFileBlock = getParentFileBlock(node);
            if (parentFileBlock != null)
            {
                string filename = parentFileBlock.Attribute("ID_STR").Value;
                node.SetAttributeValue("file", filename);
            }
            else
            {
                node.SetAttributeValue("file", "");
            }
        }

        private static XElement getParentFileBlock(XElement node)
        {
            if (node == null) return null;
            if (node.Name.Equals(XName.Get("FileBlock")))
            {
                return node;
            }
            return getParentFileBlock(node.Parent);
        }

        public static XDocument ResolvePackages(XDocument doc)
        {
            Util.CheckGen(doc, "1.0", "2.1");
            XDocument result = new XDocument(doc);
            Util.SetGen(result, "1.0", "2.2");
            IEnumerable<XElement> reqdeclNodes =
                from AnyElement in result.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("RequirementDecl")))
                    )
                select AnyElement;

            foreach (XElement node in reqdeclNodes)
            {
                ResolvePackage(node);
            }
            return result;
        }

        private static void ResolvePackage(XElement node)
        {
            IEnumerable<XElement> precedingPackageDeclarations =
                from AnyElement in node.ElementsBeforeSelf()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("PackageDecl")))
                    )
                select AnyElement;
            XElement[] precedingPackageDeclarationsArray = precedingPackageDeclarations.ToArray(); // cast it to array so we can manipulate (i.e. delete) the elements

            if (precedingPackageDeclarationsArray != null && precedingPackageDeclarationsArray.Length > 0)
            {
                XElement nearestPrecedingPackageDeclaration = precedingPackageDeclarationsArray[precedingPackageDeclarationsArray.Length - 1];
                string packagename = nearestPrecedingPackageDeclaration.Attribute("ID_STR").Value;
                node.SetAttributeValue("package", packagename);
            }
            else
            {
                XElement parent = node.Parent;
                if (parent.Name.Equals("FileBlock"))
                {
                    string packagename = parent.Attribute("ID_STR").Value;
                    node.SetAttributeValue("package", packagename);
                }
                else
                {
                    node.SetAttributeValue("package", DefaultRequiremtsPackageName);
                }
            }
        }

        public static XDocument TidyPackageDeclarations(XDocument doc)
        {
            Util.CheckGen(doc, "1.0", "2.2");
            XDocument result = new XDocument(doc);
            Util.SetGen(result, "1.0", "3");
            IEnumerable<XElement> packdeclNodes =
                from AnyElement in result.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("PackageDecl")))
                    )
                select AnyElement;

            XElement[] packdeclArry = packdeclNodes.ToArray();
            SortedSet<string> packageNames = new SortedSet<string>();
            foreach (XElement node in packdeclArry)
            {
                packageNames.Add(node.Attribute("ID_STR").Value);
                node.Remove();
            }
            foreach (string packageName in packageNames)
            {
                CollectReqDeclsToPackage(result, packageName);
            }
            CollectReqDeclsToPackage(result, DefaultRequiremtsPackageName);
            return result;
        }

        private static void CollectReqDeclsToPackage(XDocument target, string packageName)
        {
            XElement root = target.Root;
            XElement newPackageNode = new XElement("package");
            newPackageNode.SetAttributeValue("name", packageName);
            root.Add(newPackageNode);
            IEnumerable<XElement> reqdeclNodes =
                from AnyElement in target.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("RequirementDecl")))
                    && (((XElement)AnyElement).Attribute("package").Value.Equals(packageName))
                    )
                select AnyElement;
            MoveNodesToNewParent(newPackageNode, reqdeclNodes);
        }

        private static void MoveNodesToNewParent(XElement newParent, IEnumerable<XElement> nodes)
        {
            XElement[] nodesArray = nodes.ToArray();
            foreach (XElement node in nodesArray)
            {
                node.Remove();
                newParent.Add(node);
            }
        }
    }
}
