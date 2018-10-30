// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using RapidXamlToolkit.Analyzers;
using RapidXamlToolkit.Commands;
using RapidXamlToolkit.Logging;

namespace RapidXamlToolkit.Analyzers.Diagnostics
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class RX0001CsSetDatacontext : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "RX0001";

        // TODO: Localize this text
        internal static readonly LocalizableString Title = "Analyzer1 Title";
        internal static readonly LocalizableString MessageFormat = "Analyzer1 '{0}'";
        internal const string Category = "Analyzer1 Category";

        internal static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, true);

        private ILogger logger = new RxtLogger();

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get { return ImmutableArray.Create(Rule); }
        }

        public override void Initialize(AnalysisContext context)
        {
            // context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
            context.RegisterSyntaxTreeAction(this.AnalyzeSyntaxTree);
        }

        private void AnalyzeSyntaxTree(SyntaxTreeAnalysisContext context)
        {
            var settings = AnalyzerBase.GetSettings();

            if (settings.IsActiveProfileSet)
            {
                var profile = settings.GetActiveProfile();
                ////var dte = await Instance.ServiceProvider.GetServiceAsync(typeof(DTE)) as DTE;

                // TODO: create a new VSAbstraction that can work here
                //var logic = new SetDataContextCommandLogic(profile, this.logger, new VisualStudioAbstraction(dte));

                //if (logic.ShouldEnableCommand()) // TODO: review renaming this method (or create an overload)
                //{
                //    // TODO: Get location for diagnostic
                //    //var diagnostic = Diagnostic.Create(Rule, namedTypeSymbol.Locations[0]);
                //    //context.ReportDiagnostic(diagnostic);
                //}
            }
        }

        ////private static void AnalyzeSymbol(SymbolAnalysisContext context)
        ////{
        ////    // TODO: Replace the following code with your own analysis, generating Diagnostic objects for any issues you find
        ////    var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;

        ////    // Find just those named type symbols with names containing lowercase letters.
        ////    if (namedTypeSymbol.Name.ToCharArray().Any(char.IsLower))
        ////    {
        ////        // For all such symbols, produce a diagnostic.
        ////        var diagnostic = Diagnostic.Create(Rule, namedTypeSymbol.Locations[0], namedTypeSymbol.Name);

        ////        context.ReportDiagnostic(diagnostic);
        ////    }
        ////}
    }
}
