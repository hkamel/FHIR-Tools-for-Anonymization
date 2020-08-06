﻿using System.Data;
using System.Linq;
using MicrosoftFhir.Anonymizer.Core.Visitors;
using Hl7.Fhir.ElementModel;

namespace MicrosoftFhir.Anonymizer.Core.Extensions
{
    public static class ElementNodeVisitorExtensions
    {
        public static void Accept(this ElementNode node, AbstractElementNodeVisitor visitor)
        {
            bool shouldVisitChild = visitor.Visit(node);

            if (shouldVisitChild)
            {
                foreach (var child in node.Children().Cast<ElementNode>())
                {
                    child.Accept(visitor);
                }
            }

            visitor.EndVisit(node);
        }
    }
}