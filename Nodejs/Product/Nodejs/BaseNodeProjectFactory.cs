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
using System.Runtime.InteropServices;
using Microsoft.NodejsTools.Project;
using Microsoft.VisualStudioTools.Project;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace Microsoft.NodejsTools {
    [Guid(Guids.NodejsBaseProjectFactoryString)]
    class BaseNodeProjectFactory : ProjectFactory {
        public BaseNodeProjectFactory(NodejsProjectPackage package) : base(package) {
        }

        internal override ProjectNode CreateProject() {
            NodejsProjectNode project = new NodejsProjectNode((NodejsProjectPackage)Package);
            project.SetSite((IOleServiceProvider)((IServiceProvider)Package).GetService(typeof(IOleServiceProvider)));
            return project;
        }
    }
}
