﻿
// ReSharper disable once CheckNamespace
namespace CPF.Styling
{
    internal sealed class NthLastOfTypeSelector : NthChildSelector, IToString
    {
        public override bool Select(UIElement element)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            return FormatSelector(PseudoSelectorPrefix.PseudoFunctionNthLastOfType);
        }
    }
}