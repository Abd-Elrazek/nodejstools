﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System;

namespace Microsoft.NodejsTools.Jade {
    /// <summary>
    /// Text provider. HTML parser calls this interface to retrieve text.
    /// Can be implemented on a string <seealso cref="TextStream"/> or
    /// on a Visual Studio ITextBuffer (see Microsoft.Html.Editor implementation)
    /// </summary>
    interface ITextProvider {
        /// <summary>Text length</summary>
        int Length { get; }

        /// <summary>
        /// Retrieves character at a given position. 
        /// Returns 0 if index is out of range. Must no throw.
        /// </summary>
        char this[int position] { get; }

        /// <summary>Retrieves a substring from text rangen</summary>
        string GetText(ITextRange range);

        /// <summary>Finds first index of a text sequence. Returns -1 if not found.</summary>
        int IndexOf(string text, int startPosition, bool ignoreCase);

        /// <summary>Finds first index of a text sequence. Returns -1 if not found.</summary>
        int IndexOf(string text, ITextRange range, bool ignoreCase);

        /// <summary>Compares text range to a given string.</summary>
        bool CompareTo(int position, int length, string text, bool ignoreCase);

        /// <summary>Clones text provider and all its data (typically for use in another thread).</summary>
        ITextProvider Clone();

        /// <summary>Snapshot version.</summary>
        int Version { get; }

        /// <summary>Fires when text buffer content changes.</summary>
        event EventHandler<TextChangeEventArgs> OnTextChange;
    }
}
