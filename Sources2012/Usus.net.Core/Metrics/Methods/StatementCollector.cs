using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;
using Microsoft.Cci.ILToCodeModel;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal class StatementCollector : CodeTraverser
    {
        bool requireLocations;
        List<IStatement> statements;

        public int ResultCount
        {
            get { return statements.Count; }
        }

        public StatementCollector(PdbReader pdb)
        {
            statements = new List<IStatement>();
            requireLocations = pdb != null;
        }

        public override void TraverseChildren(IStatement statement)
        {
            if (statement is IEmptyStatement) return;
            if (statement is IReturnStatement && (statement as IReturnStatement).Expression == null) return;

            RememberStatement(statement);
            base.TraverseChildren(statement);
        }

        private void RememberStatement(IStatement statement)
        {
            if (requireLocations)
                RememberStatementWithLocation(statement);
            else
                RememberStatementWithoutLocation(statement);
        }

        private void RememberStatementWithLocation(IStatement statement)
        {
            if (HasLocation(statement) || IsConditional(statement) || IsDeclaration(statement))
                statements.Add(statement);
        }

        private void RememberStatementWithoutLocation(IStatement statement)
        {
            if (IsNotBlock(statement))
                statements.Add(statement);
        }

        private bool IsNotBlock(IStatement statement)
        {
            return !(statement is BasicBlock);
        }

        private bool HasLocation(IStatement statement)
        {
            return statement.Locations.Any();
        }

        private bool IsConditional(IStatement statement)
        {
            return statement is IConditionalStatement;
        }

        private bool IsDeclaration(IStatement statement)
        {
            var declaration = statement as ILocalDeclarationStatement;
            return declaration != null && declaration.InitialValue != null;
        }
    }
}
