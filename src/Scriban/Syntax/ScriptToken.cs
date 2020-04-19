// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Collections.Generic;

namespace Scriban.Syntax
{
    /// <summary>
    /// A verbatim node (use for custom parsing).
    /// </summary>
    public partial class ScriptToken : ScriptNode
    {
        public static ScriptToken Equal() => new ScriptToken("=");

        public static ScriptToken Pipe() => new ScriptToken("|");

        public static ScriptToken PipeGreater() => new ScriptToken("|>");

        public static ScriptToken OpenParen() => new ScriptToken("(");

        public static ScriptToken CloseParen() => new ScriptToken(")");
        
        public ScriptToken()
        {
        }

        public ScriptToken(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public override object Evaluate(TemplateContext context)
        {
            // Nothing to evaluate
            return null;
        }

        public override void Write(TemplateRewriterContext context)
        {
            context.Write(Value);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}