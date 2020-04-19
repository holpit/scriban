// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license. 
// See license.txt file in the project root for full license information.

using Scriban.Parsing;
using System.Collections.Generic;

namespace Scriban.Syntax
{
    public partial class ScriptPage : ScriptNode
    {
        private ScriptBlockStatement _frontMatter;
        private ScriptBlockStatement _body;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptPage"/> class.
        /// </summary>
        public ScriptPage()
        {
        }

        /// <summary>
        /// Gets or sets the front matter. May be <c>null</c> if script is not parsed using  <see cref="ScriptMode.FrontMatterOnly"/> or <see cref="ScriptMode.FrontMatterAndContent"/>. See remarks.
        /// </summary>
        /// <remarks>
        /// Note that this code block is not executed when evaluating this page. It has to be evaluated separately (usually before evaluating the page).
        /// </remarks>
        public ScriptBlockStatement FrontMatter
        {
            get => _frontMatter;
            set => ParentToThis(ref _frontMatter, value);
        }

        public ScriptBlockStatement Body
        {
            get => _body;
            set => ParentToThis(ref _body, value);
        }

        public override object Evaluate(TemplateContext context)
        {
            return context.Evaluate(Body);
        }

        public override void Write(TemplateRewriterContext context)
        {
            context.Write(Body);
        }
    }
}