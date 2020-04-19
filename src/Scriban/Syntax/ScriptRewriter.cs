// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Collections.Generic;

namespace Scriban.Syntax
{
    /// <summary>
    /// Base class for a script rewriter.
    /// </summary>
    public abstract partial class ScriptRewriter : ScriptVisitor<ScriptNode>
    {
        protected ScriptRewriter()
        {
            CopyTrivias = true;
        }
        
        public bool CopyTrivias { get; set; }
        
        public override ScriptNode Visit(ScriptNode node)
        {
            if (node == null) return null;
            var newNode = node.Accept(this);

            if (CopyTrivias && !ReferenceEquals(node, newNode))
            {
                return newNode.WithTriviaAndSpanFrom(node);
            }

            return newNode;
        }

        public override ScriptNode Visit(ScriptVariableGlobal node)
        {
            return new ScriptVariableGlobal(node.Name);
        }

        public override ScriptNode Visit(ScriptVariableLocal node)
        {
            return new ScriptVariableLocal(node.Name);
        }

        public override ScriptNode Visit(ScriptVariableLoop node)
        {
            return new ScriptVariableLoop(node.Name);
        }

        protected ScriptList<TNode> VisitAll<TNode>(ScriptList<TNode> nodes)
            where TNode : ScriptNode
        {
            if (nodes == null)
                return null;

            var newNodes = new ScriptList<TNode>();
            foreach (var node in nodes)
            {
                var newNode = (TNode) Visit(node);
                newNodes.Add(newNode);
            }
            return newNodes;
        }
    }
}
